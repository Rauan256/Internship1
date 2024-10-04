
using Microsoft.EntityFrameworkCore;
using Internship.Models;
using Internship.Services;
using Microsoft.AspNetCore.Mvc;


namespace Internship.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = context.Products.ToList();
            return Ok(products); 
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); // 
            }
            return Ok(product); // Return the found product
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            // Save the new product in the database
            var product = new Product()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                CreatedAt = DateTime.Now
            };

            context.Products.Add(product);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product); 
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); 
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the product in the database
            product.Name = productDto.Name;
            product.Brand = productDto.Brand;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.Description = productDto.Description;

            context.SaveChanges();

            return NoContent(); 
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); 
            }

            context.Products.Remove(product);
            context.SaveChanges();

            return NoContent(); 
        }
    }
}
