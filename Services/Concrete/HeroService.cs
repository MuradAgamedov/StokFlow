using ModernWMC.Data.Abstract;
using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class HeroService : IHeroService
    {
        private readonly IHeroDal _heroDal;
        private readonly IFileService _fileService;

        public HeroService(IHeroDal heroDal, IFileService fileService)
        {
            _heroDal = heroDal;
            _fileService = fileService;
        }

        public async Task<Hero>? LoadFirstAsync()
        {
            return await _heroDal.LoadFirst();
        }

        public async Task<bool> UpdateAsync(Hero entity, IFormFile? image)
        {
            if (image != null)
            {
                // Delete old image if it exists and is not the default placeholder
                if (!string.IsNullOrEmpty(entity.ImageUrl) && entity.ImageUrl != "Image.jpg")
                {
                    _fileService.DeleteFile(entity.ImageUrl, "uploads");
                }

                // Upload new image
                var fileName = await _fileService.SaveFileAsync(image, "uploads");
                if (!string.IsNullOrEmpty(fileName))
                {
                    entity.ImageUrl = fileName;
                }
            }

            return await _heroDal.Update(entity);
        }
    }
}
