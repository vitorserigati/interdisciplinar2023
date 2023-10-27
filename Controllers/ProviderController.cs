
using Microsoft.AspNetCore.Mvc;
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

    }
}
