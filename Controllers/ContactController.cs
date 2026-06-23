using Microsoft.AspNetCore.Mvc;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using ModernWMC.ViewModels;

namespace ModernWMC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IPhoneService _phoneService;
        private readonly IEmailService _emailService;
        private readonly IAddressService _addressService;
        private readonly IMapService _mapService;
        private readonly IContactMessageService _contactMessageService;


        public ContactController(IPhoneService phoneService, IEmailService emailService,
            IAddressService addressService, IMapService mapService, IContactMessageService contactMessageService)
        {
            _phoneService = phoneService;
            _emailService = emailService;
            _addressService = addressService;
            _mapService = mapService;
            _contactMessageService = contactMessageService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ContactPageViewModel
            {
                Contact = await LoadContactViewData(),
                Message = new ContactMessageViewModel()
            };
            return View(viewModel);

        }


        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> Index(ContactPageViewModel viewModel)
        {
            ModelState.Remove("Contact");
            if (!ModelState.IsValid)
            {
                viewModel.Contact = await LoadContactViewData();
                return View(viewModel);
            }

            var contact = new ContactMessage
            {
                FullName = viewModel.Message.FullName,
                Email = viewModel.Message.Email,
                Subject = viewModel.Message.Subject,
                Message = viewModel.Message.Message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _contactMessageService.AddAsync(contact);
            if (result > 0)
            {
                TempData["SuccessMessage"] = "Mesajınız göndərildi! Ən qısa zamanda sizə geri dönüş ediləcək!";
            }
            return RedirectToAction(nameof(Index));
        }


        protected async Task<ContactViewModel> LoadContactViewData()
        {
            return new ContactViewModel
            {
                Phones = (await _phoneService.LoadAllAsync(p => p.IsActive))
             .OrderBy(p => p.order)
             .ToList(),

                Emails = (await _emailService.LoadAllAsync(e => e.IsActive))
             .OrderBy(e => e.order)
             .ToList(),

                Addresses = (await _addressService.LoadAllAsync(a => a.IsActive))
             .OrderBy(a => a.Order)
             .ToList(),

                Maps = (await _mapService.LoadAllAsync(m => m.IsActive))
             .OrderBy(m => m.Order)
             .ToList()
            };


        }
    }
}
