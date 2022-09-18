namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class CreateReceptionist : ComponentBase
{
    private CreatedReceptionistVM? receptionistModel;
    private Admin? admin;
    private IBrowserFile? imageFile;
    private string imageFileName = string.Empty;
    private string? relativeImagePath = null;
    private long maxFileSize = 1024 * 1024 * 5;
    private bool isLoading;
    private string? photoUploadError;
    private string? errorMessage;

    [Inject]
    public IWebHostEnvironment Environment { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IAddReceptionistCommand AddReceptionistCommand { get; set; } = null!;

    protected override void OnInitialized()
    {
        try
        {
            admin = EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
            InitialReceptionistModel();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
    }

    private void OnValidSubmit(EditContext context)
    {
        var receptionist = receptionistModel?.ConvertToDto();
        if (receptionist != null)
        {
            AddReceptionistCommand.ExecuteAsync(receptionist);
        }

        NavigationManager.NavigateTo("/admin/receptionists");
    }

    private void HandleFormReset()
    {
        InitialReceptionistModel();
        relativeImagePath = null;
        StateHasChanged();
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

        if (receptionistModel != null)
            receptionistModel.PhotoUrl = relativeImagePath;

        isLoading = false;
        StateHasChanged();

        // TODO upload on server
    }

    private void InitialReceptionistModel()
    {
        receptionistModel = new CreatedReceptionistVM();
        if (admin != null)
        {
            receptionistModel.CreatedBy = admin;
            receptionistModel.ModifiedBy = admin;
        }
    }

    private void HandleResetError()
    {
        errorMessage = null;
        InitialReceptionistModel();
        StateHasChanged();
    }
}

