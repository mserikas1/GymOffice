using GymOffice.Common.DTOs;
using System.Threading.Channels;

namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateEditReceptionistDialog : ComponentBase
{
    private Admin? admin;
    private IBrowserFile? imageFile;
    private string imageFileName = string.Empty;
    private string? relativeImagePath = null;
    private readonly long maxFileSize = 1024 * 1024 * 5;
    private bool isLoading;
    private string? photoUploadError;
    private string? errorMessage;
    private bool isShowPassword;
    private bool isActiveOriginal;
    private string? phoneNumberOriginal;
    private string? emailOriginal;
    private InputType PasswordInput = InputType.Password;
    private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;


    [Parameter]
    public bool IsEdit { get; set; }
    [Parameter]
    public ReceptionistVM? ReceptionistModel { get; set; } = new ReceptionistVM();

    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public IWebHostEnvironment Environment { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IAddReceptionistCommand AddReceptionistCommand { get; set; } = null!;
    [Inject]
    public IEditReceptionistCommand EditReceptionistCommand { get; set; } = null!;
    [Inject]
    public IIdentityRepository IdentityRepository { get; set; } = null!;


    protected override void OnInitialized()
    {
        try
        {
            admin = GetAdmin();
            if (IsEdit)
            {
                isActiveOriginal = ReceptionistModel!.IsActive;
                phoneNumberOriginal = ReceptionistModel!.PhoneNumber;
                emailOriginal = ReceptionistModel!.Email;
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
        ReceptionistModel = new ReceptionistVM();
        if (admin != null)
        {
            ReceptionistModel.CreatedBy = admin;
            ReceptionistModel.ModifiedBy = admin;
        }
        ReceptionistModel.Id = Guid.NewGuid();
        ReceptionistModel.IsActive = true;
        ReceptionistModel.CreatedAt = DateTime.Now;
    }

    private async void HandleValidSubmit()
    {
        if (CheckForAnyChanges() == false)
        {
            DialogInstance.Close();
            return;
        }
        ReceptionistModel!.ModifiedAt = DateTime.Now;
        Receptionist? receptionist = ReceptionistModel!.ConvertToDto();

        try
        {
            if (IsEdit)
            {
                await EditReceptionistCommand.ExecuteAsync(receptionist);
                receptionist = await EmployeeDataProvider.GetReceptionistByIdAsync(receptionist.Id);
                await IdentityRepository.UpdateReceptionistAsync(receptionist!);
            }
            else
            {
                await AddReceptionistCommand.ExecuteAsync(receptionist);
                await IdentityRepository.AddReceptionistAsync(ReceptionistModel);
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
        return (isActiveOriginal != ReceptionistModel!.IsActive ||
            phoneNumberOriginal != ReceptionistModel!.PhoneNumber ||
            emailOriginal != ReceptionistModel!.Email);
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

        if (ReceptionistModel != null)
            ReceptionistModel.PhotoUrl = relativeImagePath;

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

