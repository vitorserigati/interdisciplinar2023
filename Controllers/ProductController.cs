using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.Models;

namespace Interdisciplinar2023.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product?> products = await _productsRepository.GetAllProductsAsync();
            return View(products);

        }

        public async Task<IActionResult> Show(Guid id)
        {
            Product? prod = await _productsRepository.GetProductAsync(id);
            return View(prod);
        }

    }
}
