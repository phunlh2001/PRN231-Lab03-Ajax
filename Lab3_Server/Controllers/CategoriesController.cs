using Microsoft.AspNetCore.Mvc;
using Reposiories.Interface;

namespace Lab3_Server.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoriesController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
    }
}
