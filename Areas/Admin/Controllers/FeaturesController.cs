using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeaturesController : Controller
    {
        private readonly ISystemModulesStaticService _staticService;
        private readonly ISystemModulesDynamicService _dynamicService;

        public FeaturesController(
            ISystemModulesStaticService staticService,
            ISystemModulesDynamicService dynamicService)
        {
            _staticService = staticService;
            _dynamicService = dynamicService;
        }

        public async Task<IActionResult> Index()
        {
            var staticHeader = await _staticService.LoadFirstAsync();
            var dynamics = (await _dynamicService.LoadAllAsync()).ToList();

            var viewModel = new FeaturesViewModel
            {
                StaticHeaders = new SystemModulesStaticViewModel
                {
                    Id = staticHeader.Id,
                    SectionTag = staticHeader.Title,
                    SectionTitle = staticHeader.Subtitle,
                    SectionDesc = staticHeader.Description
                },
                SystemModulesDynamics = dynamics,
                SelectedCard = new SystemModulesDynamicViewModel()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveHeaders(FeaturesViewModel model)
        {
            // We only validate the StaticHeaders part of the model
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(model.StaticHeaders.SectionTag))
                ModelState.AddModelError("StaticHeaders.SectionTag", "Bölmə etiketi boş ola bilməz.");
            if (string.IsNullOrWhiteSpace(model.StaticHeaders.SectionTitle))
                ModelState.AddModelError("StaticHeaders.SectionTitle", "Əsas başlıq boş ola bilməz.");
            if (string.IsNullOrWhiteSpace(model.StaticHeaders.SectionDesc))
                ModelState.AddModelError("StaticHeaders.SectionDesc", "Açıqlama mətni boş ola bilməz.");

            if (!ModelState.IsValid)
            {
                var staticHeader = await _staticService.LoadFirstAsync();
                var dynamics = (await _dynamicService.LoadAllAsync()).ToList();
                model.SystemModulesDynamics = dynamics;
                return View("Index", model);
            }

            var entity = await _staticService.LoadFirstAsync();
            if (entity != null)
            {
                entity.Title = model.StaticHeaders.SectionTag;
                entity.Subtitle = model.StaticHeaders.SectionTitle;
                entity.Description = model.StaticHeaders.SectionDesc;
                entity.UpdatedAt = DateTime.UtcNow;

                var result = await _staticService.UpdateAsync(entity);
                if (result)
                {
                    TempData["SuccessMessage"] = "Statik başlıqlar uğurla yeniləndi!";
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SaveCard(FeaturesViewModel model)
        {
            // We only validate the SelectedCard part of the model
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(model.SelectedCard.Title))
                ModelState.AddModelError("SelectedCard.Title", "Kartın başlığı boş ola bilməz.");
            if (string.IsNullOrWhiteSpace(model.SelectedCard.IconClass))
                ModelState.AddModelError("SelectedCard.IconClass", "İkon sinifi boş ola bilməz.");
            if (string.IsNullOrWhiteSpace(model.SelectedCard.Description))
                ModelState.AddModelError("SelectedCard.Description", "Açıqlama boş ola bilməz.");

            if (!ModelState.IsValid)
            {
                var staticHeader = await _staticService.LoadFirstAsync();
                var dynamics = (await _dynamicService.LoadAllAsync()).ToList();
                model.StaticHeaders = new SystemModulesStaticViewModel
                {
                    Id = staticHeader.Id,
                    SectionTag = staticHeader.Title,
                    SectionTitle = staticHeader.Subtitle,
                    SectionDesc = staticHeader.Description
                };
                model.SystemModulesDynamics = dynamics;
                return View("Index", model);
            }

            var entity = await _dynamicService.GetByIdAsync(model.SelectedCard.Id);
            if (entity != null)
            {
                entity.Title = model.SelectedCard.Title;
                entity.IconClass = model.SelectedCard.IconClass;
                entity.Url = model.SelectedCard.Url;
                entity.Order = model.SelectedCard.Order;
                entity.IsActive = model.SelectedCard.IsActive;
                entity.Description = model.SelectedCard.Description;
                entity.UpdatedAt = DateTime.UtcNow;

                var result = await _dynamicService.UpdateAsync(entity);
                if (result)
                {
                    TempData["SuccessMessage"] = $"\"{entity.Title}\" modul kartı uğurla yeniləndi!";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Seçilən modul kartı tapılmadı.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
