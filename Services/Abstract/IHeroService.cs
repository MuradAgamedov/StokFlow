using ModernWMC.Models.Concrete;
using Microsoft.AspNetCore.Http;

namespace ModernWMC.Services.Abstract
{
    public interface IHeroService
    {
        Task<Hero>? LoadFirstAsync();
        Task<bool> UpdateAsync(Hero entity, IFormFile? image);
    }
}
