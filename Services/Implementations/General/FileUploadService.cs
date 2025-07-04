using woolly_friends.Services.Interfaces.General;

namespace woolly_friends.Services.Implementations.General
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string subfolder, string filenameWithoutExt)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            var fileExt = Path.GetExtension(file.FileName);
            var fileName = $"{filenameWithoutExt}{fileExt}";
            var folderPath = Path.Combine(_environment.WebRootPath, "Uploads", subfolder);
            var filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/Uploads/{subfolder}/{fileName}";
        }
    }
}
