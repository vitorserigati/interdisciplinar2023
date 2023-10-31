using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.Models;
using Interdisciplinar2023.ViewModels;

namespace Interdisciplinar2023.Controllers;

public class DashboardController : Controller
{
    private readonly IProviderRepository _providerRepository;
    private readonly IProductsRepository _productsRepository;

    public DashboardController(IProductsRepository productsRepository, IProviderRepository providerRepository)
    {
        _productsRepository = productsRepository;
        _providerRepository = providerRepository;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productsRepository.GetAllNearDate(DateTime.UtcNow.AddMonths(1));
        var providers = await _providerRepository.GetAllProviders();
        DashboardIndexViewModel nModel = new DashboardIndexViewModel
        {
            SelectedDate = DateTime.UtcNow.AddMonths(1),
            Products = products!,
            Providers = providers!
        };

        return View(nModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(DashboardIndexViewModel model)
    {
        var products = await _productsRepository.GetAllNearDate(model.SelectedDate?.ToUniversalTime() ?? DateTime.UtcNow.AddMonths(1));
        List<Provider> providers = new List<Provider>();
        foreach (Product prod in products)
        {
            providers.Add(await _providerRepository.GetProviderAsync(prod.ProviderId));
        }

        model.Providers = providers;
        model.Products = products!;

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
