<<<<<<< HEAD
﻿namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class CreateReceptionist : ComponentBase
{
    private ReceptionistVM? receptionistModel;
=======
﻿using GymOffice.WebAdmin.Extensions;
using GymOffice.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Components.Forms;

namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class CreateReceptionist : ComponentBase
{
    private CreatedReceptionistVM? receptionistModel;
>>>>>>> oleg-feature-receptionist-pages
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

    protected override void OnAfterRender(bool firstRender)
    {
        try
        {
            if (firstRender)
            {
<<<<<<< HEAD
                admin = GetAdmin();
=======
                GetAdmin();
>>>>>>> oleg-feature-receptionist-pages
                InitialReceptionistModel();
                StateHasChanged();
            }
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

<<<<<<< HEAD
    private Admin? GetAdmin()
    {
        return EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
=======
    private void GetAdmin()
    {
        admin = EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
>>>>>>> oleg-feature-receptionist-pages
    }

    private void InitialReceptionistModel()
    {
<<<<<<< HEAD
        receptionistModel = new ReceptionistVM();
=======
        receptionistModel = new CreatedReceptionistVM();
>>>>>>> oleg-feature-receptionist-pages
        if (admin != null)
        {
            receptionistModel.CreatedBy = admin;
            receptionistModel.ModifiedBy = admin;
        }
    }

    private void HandleResetError()
    {
        errorMessage = null;
<<<<<<< HEAD
        admin = GetAdmin();
=======
        GetAdmin();
>>>>>>> oleg-feature-receptionist-pages
        InitialReceptionistModel();
        StateHasChanged();
    }
}

