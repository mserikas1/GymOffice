using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace GymOffice.WebAdmin.Pages.Admin;
public partial class CreateReceptionist : ComponentBase
{
    private CreatedReceptionistVM model = new();
    private IBrowserFile? imageFile = null;
    private string imageFileName = string.Empty;
    private string relativeImagePath = string.Empty;
    private long maxFileSize = 1024 * 1024 * 5;
    private bool isLoading;
    private string? errorMessage;

    [Inject]
    public IWebHostEnvironment Environment { get; set; } = null!;

    private void OnValidSubmit(EditContext context)
    {
        //todo
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
            errorMessage = ex.Message;
        }

        model.PhotoUrl = relativeImagePath;
        isLoading = false;
        StateHasChanged();
    }
}

