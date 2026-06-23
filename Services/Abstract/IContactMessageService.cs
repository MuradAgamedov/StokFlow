using ModernWMC.Models.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Services.Abstract
{
    public interface IContactMessageService
    {
        Task<int>? AddAsync(ContactMessage entity);
    }
}
