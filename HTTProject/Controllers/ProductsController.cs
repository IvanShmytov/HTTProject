using HTTProject.BLL.Abstract;
using HTTProject.BLL.Abstract.ViewModels;
using HTTProject.Entities;
using Microsoft.AspNetCore.Mvc;


namespace HTTProject.PL.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : Controller
    {
        private readonly IRepository<ProductVM> _repo;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IRepository<ProductVM> repo, ILogger<ProductsController> logger)
        {
            _repo = repo;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into ProductsController");
        }
        /// <summary>
        /// Return all products
        /// </summary>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAll();
            _logger.LogInformation("ProductsController - GetAll");
            return StatusCode(200, products);
        }
        /// <summary>
        /// Return product by id
        /// </summary>
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _repo.Get(id);
            if (product is null)
                throw new NullReferenceException("Продукт не найден");
            _logger.LogInformation("ProductsController - GetCategoryById");
            return StatusCode(200, product);
        }
        /// <summary>
        /// Return product by name
        /// </summary>
        [HttpGet]
        [Route("GetProductByName/{name}")]
        public async Task<IActionResult> GetProductByName([FromRoute] string name)
        {
            var product = await _repo.GetByName(name);
            if (product is null)
                throw new NullReferenceException("Продукт не найден");
            _logger.LogInformation("ProductsController - GetCategoryByName");
            return StatusCode(200, product);
        }
    }
}
