using Microsoft.AspNetCore.Http;

namespace ModernWMC.Services.Abstract
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string subFolder = "uploads");
        bool DeleteFile(string fileName, string subFolder = "uploads");
    }
}
