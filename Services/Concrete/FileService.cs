using ModernWMC.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace ModernWMC.Services.Concrete
{
    public class FileService : IFileService
    {
        public async Task<string> SaveFileAsync(IFormFile file, string subFolder = "uploads")
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subFolder);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public bool DeleteFile(string fileName, string subFolder = "uploads")
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subFolder, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }
    }
}
