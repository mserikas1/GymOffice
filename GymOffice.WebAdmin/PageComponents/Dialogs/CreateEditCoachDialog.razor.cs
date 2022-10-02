namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateEditCoachDialog : ComponentBase
{
    private Admin? admin;
    private IBrowserFile? imageFile;
    private string imageFileName = string.Empty;
    private string relativeImagePath = "";
    private readonly long maxFileSize = 1024 * 1024 * 5;
    private bool isLoading;
    private string? photoUploadError;
    private string? errorMessage;
    private bool isShowPassword;
    private bool isActiveOriginal;
    private string? phoneNumberOriginal;
    private string? emailOriginal;
    private string? educationOriginal;
    private string? descriptionOriginal;
    private string? photoOriginal;
    private InputType PasswordInput = InputType.Password;
    private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;


    [Parameter]
    public bool IsEdit { get; set; }
    [Parameter]
    public CoachVM? CoachModel { get; set; } = new();

    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public IWebHostEnvironment Environment { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IAddCoachCommand AddCoachCommand { get; set; } = null!;
    [Inject]
    public IEditCoachCommand EditCoachCommand { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;    


    protected override void OnInitialized()
    {
        try
        {
            admin = GetAdmin();
            if (IsEdit)
            {
                isActiveOriginal = CoachModel!.IsActive;
                phoneNumberOriginal = CoachModel!.PhoneNumber;
                emailOriginal = CoachModel!.Email;
                educationOriginal = CoachModel!.Education;
                descriptionOriginal = CoachModel!.Description;
                photoOriginal = CoachModel!.PhotoUrl;
            }
            else
            {
                InitialCoachModel();
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

    private void InitialCoachModel()
    {
        CoachModel = new CoachVM();
        if (admin != null)
        {
            CoachModel.CreatedBy = admin;
            CoachModel.ModifiedBy = admin;
        }
        CoachModel.Id = Guid.NewGuid();
        CoachModel.IsActive = true;
        CoachModel.CreatedAt = DateTime.Now;
    }

    private async void HandleValidSubmit()
    {
        if (CheckForAnyChanges() == false)
        {
            DialogInstance.Close();
            return;
        }
        if (string.IsNullOrWhiteSpace(CoachModel!.PhotoUrl))
        {
            errorMessage = "The photo is required. Please upload.";
            DisplayErrorDialog(errorMessage);
            return;
        }

        try
        {
            CoachModel!.ModifiedAt = DateTime.Now;
            Coach coach = CoachModel!.ConvertToDto();
            if (IsEdit)
            {
                await EditCoachCommand.ExecuteAsync(coach);
            }
            else
            {
                await AddCoachCommand.ExecuteAsync(coach);
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            DisplayErrorDialog(errorMessage);
            StateHasChanged();
        }

        DialogInstance.Close();
    }

    private void DisplayErrorDialog(string message)
    {  
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = false, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("ErrorMessage", message);
        var dialog = DialogService.Show<ErrorDisplay>("ErrorDisplayDialog", parameters, options);
    }

    private bool CheckForAnyChanges()
    {
        return (isActiveOriginal != CoachModel!.IsActive ||
            phoneNumberOriginal != CoachModel!.PhoneNumber ||
            emailOriginal != CoachModel!.Email ||
            educationOriginal != CoachModel!.Education ||
            descriptionOriginal != CoachModel!.Description ||
            photoOriginal != CoachModel!.PhotoUrl);
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

        if (CoachModel != null)
            CoachModel.PhotoUrl = relativeImagePath;

        isLoading = false;
        StateHasChanged();

        // TODO upload on server
    }

    private void HandleFormReset()
    {
        InitialCoachModel();
        relativeImagePath = "";
        StateHasChanged();
    }

    private void HandleResetError()
    {
        errorMessage = null;
        InitialCoachModel();
        StateHasChanged();
    }

    private void HandleCancel()
    {
        DialogInstance.Cancel();
    }

    void ShowPassword_Click()
    {
        if (isShowPassword)
        {
            isShowPassword = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInput = InputType.Password;
        }
        else
        {
            isShowPassword = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInput = InputType.Text;
        }
    }
}