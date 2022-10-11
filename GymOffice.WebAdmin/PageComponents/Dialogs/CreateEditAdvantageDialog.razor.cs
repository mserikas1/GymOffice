using GymOffice.Common.DTOs;
using System.Threading.Channels;

namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateEditAdvantageDialog : ComponentBase
{
    private Admin? admin;
    private IBrowserFile? imageFile;
    private string imageFileName = string.Empty;
    private string? relativeImagePath = null;
    private readonly long maxFileSize = 1024 * 1024 * 5;
    private bool isLoading;
    private string? photoUploadError;
    private string? errorMessage;
    private string? titleOriginal;
    private string? descriptionOriginal;
    private string? photoUrlOriginal;


    [Parameter]
    public bool IsEdit { get; set; }
    [Parameter]
    public AdvantageVM? AdvantageModel { get; set; } = new AdvantageVM();

    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;
    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IWebHostEnvironment Environment { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IAddAdvantageCommand AddAdvantageCommand { get; set; } = null!;
    [Inject]
    public IEditAdvantageCommand EditAdvantageCommand { get; set; } = null!;


    protected override void OnInitialized()
    {
        try
        {
            admin = GetAdmin();
            if (IsEdit)
            {
                titleOriginal = AdvantageModel!.Title;
                descriptionOriginal = AdvantageModel!.Description;
                photoUrlOriginal = AdvantageModel!.PhotoUrl;
            }
            else
            {
                InitialReceptionistModel();
            }
            StateHasChanged();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
    }

    private Admin? GetAdmin()
    {
        return EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
    }

    private void InitialReceptionistModel()
    {
        AdvantageModel = new AdvantageVM();
        if (admin != null)
        {
            AdvantageModel.CreatedBy = admin;
            AdvantageModel.ModifiedBy = admin;
        }
        AdvantageModel.Id = Guid.NewGuid();
        AdvantageModel.CreatedAt = DateTime.Now;
    }

    private async void HandleValidSubmit()
    {
        if (CheckForAnyChanges() == false)
        {
            DialogInstance.Close();
            return;
        }
        AdvantageModel!.ModifiedAt = DateTime.Now;
        Advantage? advantage = AdvantageModel!.ConvertToDto();

        try
        {
            if (IsEdit)
            {
                await EditAdvantageCommand.ExecuteAsync(advantage);
            }
            else
            {
                await AddAdvantageCommand.ExecuteAsync(advantage);
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

    private bool CheckForAnyChanges()
    {
        return (titleOriginal != AdvantageModel!.Title ||
            descriptionOriginal != AdvantageModel!.Description || photoUrlOriginal != AdvantageModel.PhotoUrl);
    }

    private async Task UploadPhoto(InputFileChangeEventArgs e)
    {
        isLoading = true;
        imageFile = e.File;
        imageFileName = imageFile.Name;

        try
        {
            var path = Path.Combine(Environment.WebRootPath, @"Data\Photos", imageFileName);

            await using FileStream fs = new(path, FileMode.Create);
            await imageFile.OpenReadStream(maxFileSize).CopyToAsync(fs);
            relativeImagePath = "Data/Photos/" + imageFileName;
        }
        catch (Exception ex)
        {
            photoUploadError = ex.Message;
        }

        if (AdvantageModel != null)
            AdvantageModel.PhotoUrl = relativeImagePath;

        isLoading = false;
        StateHasChanged();

        // TODO upload on server
    }

    private void HandleFormReset()
    {
        InitialReceptionistModel();
        relativeImagePath = null;
        StateHasChanged();
    }

    private void HandleResetError()
    {
        errorMessage = null;
        InitialReceptionistModel();
        StateHasChanged();
    }

    private void HandleCancel()
    {
        DialogInstance.Cancel();
    }
}

