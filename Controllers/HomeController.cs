using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModernWMC.Models;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using ModernWMC.Services.Concrete;
using ModernWMC.ViewModels;

namespace ModernWMC.Controllers;

public class HomeController : Controller
{
    private readonly IHeroService _heroService;
    private readonly ISystemModulesStaticService _systemModulesStaticService;
    private readonly ISystemModulesDynamicService _systemModulesDynamicService;
    private readonly IStatisticsService _statisticsService;



    public HomeController(IHeroService heroService, ISystemModulesStaticService systemModulesStaticService, ISystemModulesDynamicService systemModulesDynamicService, IStatisticsService statisticsService)
    {
        _heroService = heroService;
        _systemModulesStaticService = systemModulesStaticService;
        _systemModulesDynamicService = systemModulesDynamicService;
        _statisticsService = statisticsService;



    }

    public async Task<IActionResult> Index()
    {
        var hero = await _heroService.LoadFirstAsync();
        var systemModulesStaticService = await _systemModulesStaticService.LoadFirstAsync();
        var systemModulesDynamics = await _systemModulesDynamicService.LoadAllAsync();
        var statistics = await _statisticsService.LoadAllAsync();



        var homeViewModel = new HomeViewModel
        {
            Hero = hero,
            SystemModulesStatic = systemModulesStaticService,
            SystemModulesDynamics = systemModulesDynamics,
            Statistics = statistics


        };
        return View(homeViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
