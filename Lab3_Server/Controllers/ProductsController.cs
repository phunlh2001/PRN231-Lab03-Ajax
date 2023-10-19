using BusinessObjects.Data;
using Microsoft.AspNetCore.Mvc;
using Reposiories.Interface;

namespace Lab3_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var prod = _repo.GetProduct(id);
            if (prod == null) return NotFound("Product not found.");

            return Ok(prod);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product prod)
        {
            if (prod == null) return BadRequest("Information is required");

            if (ModelState.IsValid) _repo.InsertProduct(prod);
            else return BadRequest("Invalid");

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Product prod)
        {
            if (prod == null) return BadRequest("information is required");

            var p = _repo.GetProduct(id);
            if (p == null) return NotFound("Product not found");

            _repo.UpdateProduct(prod);
            return Ok(prod);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var p = _repo.GetProduct(id);
            if (p == null) return NotFound("Product not found");

            _repo.DeleteProduct(id);
            return NoContent();
        }
    }
}
