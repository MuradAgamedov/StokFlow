using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewData["CurrentFilter"] = search;
            IEnumerable<Company> companies;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                companies = await _companyService.LoadAllAsync(
                    e => e.Name.ToLower().Contains(lowerSearch) ||
                         (e.Voen != null && e.Voen.ToLower().Contains(lowerSearch)) ||
                         (e.ContactPerson != null && e.ContactPerson.ToLower().Contains(lowerSearch)) ||
                         (e.Address != null && e.Address.ToLower().Contains(lowerSearch))
                );
            }
            else
            {
                companies = await _companyService.LoadAllAsync();
            }

            var mappedCompanies = companies.Select(c => new CompanyViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Voen = c.Voen,
                ContactPerson = c.ContactPerson,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                IsActive = c.IsActive
            }).ToList();

            return View(mappedCompanies);
        }

        public IActionResult Create()
        {
            return View(new CompanyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var company = new Company
            {
                Name = model.Name,
                Voen = model.Voen,
                ContactPerson = model.ContactPerson,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _companyService.AddAsync(company);
            TempData["SuccessMessage"] = "Yeni firma uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            var viewModel = new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                Voen = company.Voen,
                ContactPerson = company.ContactPerson,
                Email = company.Email,
                Phone = company.Phone,
                Address = company.Address,
                IsActive = company.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var company = await _companyService.GetByIdAsync(model.Id);
            if (company == null)
            {
                return NotFound();
            }

            company.Name = model.Name;
            company.Voen = model.Voen;
            company.ContactPerson = model.ContactPerson;
            company.Email = model.Email;
            company.Phone = model.Phone;
            company.Address = model.Address;
            company.IsActive = model.IsActive;
            company.UpdatedAt = DateTime.UtcNow;

            await _companyService.UpdateAsync(company);
            TempData["SuccessMessage"] = "Firma məlumatları uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Firma uğurla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Firma silinərkən xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
