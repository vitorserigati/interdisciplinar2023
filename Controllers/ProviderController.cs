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

        public IActionResult Create()
        {
            CreateProviderViewModel model = new CreateProviderViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateProviderViewModel model)
        {
            Console.WriteLine(model.CorporateName);
            if (ModelState.IsValid)
            {
                Provider provider = new Provider
                {
                    CorporateName = model.CorporateName,
                    Document = model.Document,
                    Street = model.Street,
                    Neighborhood = model.Neighborhood,
                    City = model.City,
                    State = model.State,
                    PostalCode = model.PostalCode,
                    Email = model.Email,
                    Phone = model.Phone,
                    Celphone = model.Celphone
                };

                _providerRepository.Add(provider);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var provider = await _providerRepository.GetProviderAsync(id);
            if (provider == null) return RedirectToAction("Index");

            EditProviderViewModel model = new EditProviderViewModel
            {
                CorporateName = provider.CorporateName!,
                Document = provider.Document!,
                Street = provider.Street!,
                Neighborhood = provider.Neighborhood!,
                City = provider.City!,
                State = provider.State!,
                PostalCode = provider.PostalCode!,
                Email = provider.Email!,
                Phone = provider.Phone!,
                Celphone = provider.Celphone!,
                Id = provider.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProviderViewModel reModel)
        {
            if (ModelState.IsValid)
            {
                var provider = await _providerRepository.GetProviderAsync(reModel.Id);

                provider!.Celphone = reModel.Celphone;
                provider.Phone = reModel.Phone;
                provider.Email = reModel.Email;
                provider.PostalCode = reModel.PostalCode;
                provider.State = reModel.State;
                provider.Neighborhood = reModel.Neighborhood;
                provider.City = reModel.City;
                provider.Street = reModel.Street;
                provider.Document = reModel.Document;
                provider.CorporateName = reModel.CorporateName;

                if (_providerRepository.Update(provider))
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View(reModel);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var provider = await _providerRepository.GetProviderAsync(id);
            _providerRepository.Delete(provider!);

            return RedirectToAction("Index");
        }

    }
}
