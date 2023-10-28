using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.Models;
using Interdisciplinar2023.ViewModels;

namespace Interdisciplinar2023.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductsRepository _productsRepository;
        private readonly IProviderRepository _providerRepository;

        public ProductController(IProductsRepository productsRepository, IProviderRepository providerRepository)
        {
            _productsRepository = productsRepository;
            _providerRepository = providerRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product?> products = await _productsRepository.GetAllProductsAsync();
            return View(products);

        }

        public async Task<IActionResult> Details(Guid id)
        {
            Product? prod = await _productsRepository.GetProductAsync(id);

            return View(prod);

        }

        public async Task<IActionResult> Create()
        {
            CreateProductViewModel prod = new CreateProductViewModel
            {
                ProviderList = await _providerRepository.GetAllProviders()
            };
            return View(prod);
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel prod)
        {
            if (!ModelState.IsValid)
            {
                prod.ProviderList = _providerRepository.GetAllProviders().Result;
                return View(prod);

            }

            var newProd = new Product
            {
                Name = prod.Name,
                Value = prod.Value,
                Corridor = prod.Corridor,
                Shelf = prod.Shelf,
                Batch = prod.Batch,
                Validity = prod.Validity.ToUniversalTime(),
                Category = prod.Category,
                Description = prod.Description,
                Quantity = prod.Quantity,
                ProviderId = prod.ProviderId
            };

            _productsRepository.Add(newProd);

            return RedirectToAction("Index");


        }

        public IActionResult Edit(Guid id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Product prod)
        {
            _productsRepository.Update(prod);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}


