using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.Models;
using Interdisciplinar2023.Data.Enum;
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
            IEnumerable<Provider?> providers = await _providerRepository.GetAllProviders();
            IndexProductViewModel model = new IndexProductViewModel
            {
                Products = products,
                Providers = providers
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexProductViewModel model)
        {
            IEnumerable<Product?> products;
            Guid id = new Guid();
            Console.WriteLine($"Provider ID: {model.SelectedProviderId}. Category: {model.SelectedCategory}");
            if (!(model.SelectedProviderId == id) && model.SelectedCategory != ProductCategory.None)
            {
                products = await _productsRepository.GetAllFromProviderAndCategoryAsync(model.SelectedProviderId, model.SelectedCategory);
            }
            else if (!(model.SelectedProviderId == id))
            {
                products = await _productsRepository.GetAllFromProviderAsync(model.SelectedProviderId);
            }
            else if (model.SelectedCategory != ProductCategory.None)
            {
                products = await _productsRepository.GetAllFromCategory(model.SelectedCategory);
            }
            else
            {
                products = await _productsRepository.GetAllProductsAsync();
            }


            IEnumerable<Provider?> providers = await _providerRepository.GetAllProviders();
            IndexProductViewModel newModel = new IndexProductViewModel
            {
                Products = products,
                Providers = providers
            };

            return View(newModel);
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

        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productsRepository.GetProductAsync(id);

            EditProductViewModel model = new EditProductViewModel
            {
                Id = product!.Id,
                Name = product!.Name,
                Value = product.Value,
                Corridor = product.Corridor,
                Shelf = product.Shelf,
                Batch = product.Batch,
                Validity = product.Validity,
                Category = product.Category,
                Description = product.Description,
                Quantity = product.Quantity
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditProductViewModel prod)
        {
            Product? product = await _productsRepository.GetProductAsync(id);
            if (product == null) return View("Error");

            product.Name = prod.Name;
            product.Value = prod.Value;
            product.Corridor = prod.Corridor;
            product.Shelf = prod.Shelf;
            product.Batch = prod.Batch;
            product.Validity = prod.Validity.ToUniversalTime();
            product.Category = prod.Category;
            product.Description = prod.Description;
            product.Quantity = prod.Quantity;

            _productsRepository.Update(product);


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var prod = await _productsRepository.GetProductAsync(id);
                _productsRepository.Delete(prod!);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}


