using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.ViewModels;
using Interdisciplinar2023.Models;

namespace Interdisciplinar2023.Controllers
{
    public class ProviderController : Controller
    {

        private readonly IProviderRepository _providerRepository;

        public ProviderController(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Provider?> providers = await _providerRepository.GetAllProviders();
            return View(providers);

        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var provider = await _providerRepository.GetProviderAsync(id);
                ProviderDetailsViewModel model = new ProviderDetailsViewModel
                {
                    Id = provider!.Id,
                    CorporateName = provider.CorporateName,
                    Street = provider.Street,
                    Neighborhood = provider.Neighborhood,
                    City = provider.City,
                    State = provider.State,
                    PostalCode = provider.PostalCode,
                    Email = provider.Email,
                    Phone = provider.Phone,
                    Celphone = provider.Celphone,
                    Products = provider.Products

                };

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View("Error");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var provider = await _providerRepository.GetProviderAsync(id);
            _providerRepository.Delete(provider!);

            return RedirectToAction("Index");
        }

    }
}
