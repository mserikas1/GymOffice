using GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Delete;
using GymOffice.Common.DTOs;
using GymOffice.WebAdmin.ViewModels;
using static MudBlazor.FilterOperator;

namespace GymOffice.WebAdmin.Pages.Administrator;

[Authorize(Roles = "Admin")]
public partial class CarouselPhotosListPage : ComponentBase
{
    public string? ErrorMessage { get; set; }
    public int Counter { get; set; } = 0;
    
    public List<CarouselPhotoRowVM>? CarouselPhotoRows { get; set; }
    [Inject] public ICarouselPhotoDataProvider CarouselPhotoDataProvider { get; set; } = null!;
    [Inject] public IDeleteCarouselPhotoCommand DeleteCarouselPhotoCommand { get; set; } = null!;
    [Inject] public IDialogService DialogService { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        await GetCarouselPhotos();
    }

    protected async Task GetCarouselPhotos()
    {
        ICollection<CarouselPhoto>? carouselPhotos = await CarouselPhotoDataProvider.GetAllCarouselPhotosAsync();
        if (carouselPhotos == null)
        {
            CarouselPhotoRows = null;
            return;
        }
        int currentNum = 1;
        CarouselPhotoRows = new();
        foreach (CarouselPhoto photo in carouselPhotos)
        {
            CarouselPhotoRows.Add(new CarouselPhotoRowVM
            {
                Number = currentNum++,
                PhotoUrl = photo.PhotoUrl,
                Id = photo.Id
            });
        }
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }

    private async Task DeleteCarouselPhoto_Click(CarouselPhotoRowVM carouselPhotoRow)
    {
        bool? result = await DialogService.ShowMessageBox(
           "Warning!",
           $"Do you really want to DELETE the photo #{carouselPhotoRow.Number}?",
           yesText: "Delete", cancelText: "Cancel");
        if (result != null) // not cancelled
        {
            CarouselPhoto? photo = await CarouselPhotoDataProvider.GetCarouselPhotoByIdAsync(carouselPhotoRow.Id);
            if (photo == null)
                ErrorMessage = "Not found the photo to delete in the database";
            else
            {
                await DeleteCarouselPhotoCommand.ExecuteAsync(photo);
                // TODO remove the corresponding file from the Data/img folder (check if it's referenced only once in the database)
                await GetCarouselPhotos();
            }
            StateHasChanged();
        }
    }

    private async Task EditCarouselPhoto_Click(CarouselPhotoRowVM carouselPhotoRow)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters
        {
            { "carouselPhoto", carouselPhotoRow },
            { "IsEdit", true }
        };
        var dialog = DialogService.Show<CreateEditCarouselPhotoDialog>("CreateEditCarouselPhotoDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await GetCarouselPhotos();
            StateHasChanged();
        }
    }

    private async Task CreateCarouselPhoto_Click()
    {
        CarouselPhotoRowVM carouselPhotoRow = new CarouselPhotoRowVM
        {
            Number = CarouselPhotoRows == null ? 1 : CarouselPhotoRows.Count + 1,
            PhotoUrl = null
        };

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters
        {
            { "carouselPhoto", carouselPhotoRow },
            { "IsEdit", false }
        };
        var dialog = DialogService.Show<CreateEditCarouselPhotoDialog>("CreateEditCarouselPhotoDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await GetCarouselPhotos();
            StateHasChanged();
        }
    }

    private async Task EditCarouselPhoto_RowClick(TableRowClickEventArgs<CarouselPhotoRowVM> tableRowClickEventArgs)
    {
        await EditCarouselPhoto_Click(tableRowClickEventArgs.Item);
    }

}