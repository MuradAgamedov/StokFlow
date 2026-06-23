using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;
using Microsoft.EntityFrameworkCore;
namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewData["CurrentFilter"] = search;
            IEnumerable<Category> categories;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                categories = await _categoryService.LoadAllAsync(
                    e => e.Name.ToLower().Contains(lowerSearch) || e.CategoryCode.ToLower().Contains(lowerSearch)
                );
            }
            else
            {
                categories = await _categoryService.LoadAllAsync();
            }


            var mappedCategories = categories.Select(a => new CategoryViewModel
            {
                Id = a.Id,
                Name = a.Name,
                CategoryCode = a.CategoryCode,
                Description = a.Description,
            }).ToList();

            return View(mappedCategories);
        }

        public IActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category
            {
                Name = model.Name,
                CategoryCode = model.CategoryCode,
                Description = model.Description ?? string.Empty,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _categoryService.AddAsync(category);
            TempData["SuccessMessage"] = "Yeni kateqoriya uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                CategoryCode = category.CategoryCode,
                Description = category.Description
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = await _categoryService.GetByIdAsync(model.Id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = model.Name;
            category.CategoryCode = model.CategoryCode;
            category.Description = model.Description ?? string.Empty;
            category.UpdatedAt = DateTime.UtcNow;

            await _categoryService.UpdateAsync(category);
            TempData["SuccessMessage"] = "Kateqoriya məlumatları uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Kateqoriya uğurla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Kateqoriya silinərkən xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
