using HTTProject.BLL.Abstract;
using HTTProject.Entities;
using Microsoft.AspNetCore.Mvc;


namespace HTTProject.PL.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _repo;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IRepository<Category> repo, ILogger<CategoriesController> logger)
        {
            _repo = repo;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into CategoriesController");
        }
        /// <summary>
        /// Return all categories
        /// </summary>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repo.GetAll();
            _logger.LogInformation("CategoriesController - GetAll");
            return StatusCode(200, categories);
        }
        /// <summary>
        /// Return category by id
        /// </summary>
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category= await _repo.Get(id);
            if (category is null)
                throw new NullReferenceException("Категория не найдена");
            _logger.LogInformation("CategoriesController - GetCategoryById");
            return StatusCode(200, category);
        }
        /// <summary>
        /// Return category by name
        /// </summary>
        [HttpGet]
        [Route("GetCategoryByName/{name}")]
        public async Task<IActionResult> GetCategoryByName([FromRoute] string name)
        {
            var category = await _repo.GetByName(name);
            if (category is null)
                throw new NullReferenceException("Категория не найдена");
            _logger.LogInformation("CategoriesController - GetCategoryByName");
            return StatusCode(200, category);
        }
    }
}
