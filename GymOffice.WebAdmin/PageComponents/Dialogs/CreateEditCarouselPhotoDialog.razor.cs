using GymOffice.Common.DTOs;
using System.Threading.Channels;

namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateEditCarouselPhotoDialog : ComponentBase
{
    private IBrowserFile? imageFile;
    private string imageFileName = string.Empty;
    private string? relativeImagePath = null;
    private readonly long maxFileSize = 1024 * 1024 * 5;
    private bool isLoading;
    private string? photoUploadError;
    private string? errorMessage;
    
    [Parameter]
    public bool IsEdit { get; set; }
    [Parameter]
    public CarouselPhotoRowVM? carouselPhoto { get; set; } = null!;

    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public IWebHostEnvironment Environment { get; set; } = null!;
    [Inject]
    public ICarouselPhotoDataProvider CarouselPhotoDataProvider { get; set; } = null!;
    [Inject]
    public IAddCarouselPhotoCommand AddCarouselPhotoCommand { get; set; } = null!;
    [Inject]
    public IEditCarouselPhotoCommand EditCarouselPhotoCommand { get; set; } = null!;
    [Inject]
    public ICarouselPhotoRepository CarouselPhotoRepository { get; set; } = null!;

    private async void HandleValidSubmit()
    {
        try
        {
            if (IsEdit)
            {
                CarouselPhoto? editedPhoto = await CarouselPhotoRepository.GetCarouselPhotoByIdAsync(carouselPhoto!.Id);
                if (editedPhoto != null)
                {
                    editedPhoto.PhotoUrl = carouselPhoto.PhotoUrl;
                    await EditCarouselPhotoCommand.ExecuteAsync(editedPhoto);
                }
            }
            else
            {
                CarouselPhoto newPhoto = new CarouselPhoto();
                if (newPhoto == null)
                {
                    errorMessage = "Cannot create new entity of " + nameof(CarouselPhoto);
                    StateHasChanged();
                    return;
                }
                newPhoto.PhotoUrl = carouselPhoto!.PhotoUrl;
                await AddCarouselPhotoCommand.ExecuteAsync(newPhoto!);
            }

            StateHasChanged();
            DialogInstance.Close();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            StateHasChanged();
        }                
    }

    private async Task UploadPhoto(InputFileChangeEventArgs e)
    {
        isLoading = true;
        imageFile = e.File;
        imageFileName = imageFile.Name;

        try
        {
            var path = Path.Combine(Environment.WebRootPath, @"Data\img", imageFileName);

            await using FileStream fs = new(path, FileMode.Create);
            await imageFile.OpenReadStream(maxFileSize).CopyToAsync(fs);
            relativeImagePath = "Data/img/" + imageFileName;
        }
        catch (Exception ex)
        {
            photoUploadError = ex.Message;
        }

        if (carouselPhoto != null)
            carouselPhoto.PhotoUrl = relativeImagePath ?? "";

        isLoading = false;
        StateHasChanged();

        // TODO upload on server
    }

    private void HandleResetError()
    {
        errorMessage = null;
        StateHasChanged();
    }

    private void HandleCancel()
    {
        DialogInstance.Cancel();
    }
}

