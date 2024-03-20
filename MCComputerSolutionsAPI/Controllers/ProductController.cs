using MCComputerSolutionsAPI.DbConnection;
using MCComputerSolutionsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCComputerSolutionsAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public ProductController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {

            List<Product> products = await _databaseContext.Products.ToListAsync();

            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return BadRequest("No data");
            }
        }
    }
}
