using Microsoft.AspNetCore.Http;

namespace woolly_friends.Services.Interfaces.General
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, string subfolder, string filenameWithoutExt);
    }
}
