using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Interdisciplinar2023.Controllers;

[Authorize]
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
        var products = await _productsRepository.GetAllNearDateAndBelowAmount(DateTime.UtcNow.AddMonths(1), 10);
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
        if (model.SelectedProviderId != null)
        {
            DateTime selectedDate = model.SelectedDate?.ToUniversalTime() ?? DateTime.UtcNow.AddMonths(1);
            Guid selectedProviderId = Guid.Parse(model.SelectedProviderId!);
            var products = await _productsRepository.GetAllNearDateAndBelowAmountFromProvider(selectedDate, 10, selectedProviderId);
            var providers = await _providerRepository.GetAllProviders();

            model.Providers = providers!;
            model.Products = products!;
            model.SelectedDate = selectedDate;

            return View(model);
        }
        else
        {
            DateTime selectedDate = model.SelectedDate?.ToUniversalTime() ?? DateTime.UtcNow.AddMonths(1);
            var products = await _productsRepository.GetAllNearDateAndBelowAmount(selectedDate, 10);
            var providers = await _providerRepository.GetAllProviders();

            model.Providers = providers!;
            model.Products = products!;
            model.SelectedDate = selectedDate;
            return View(model);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
