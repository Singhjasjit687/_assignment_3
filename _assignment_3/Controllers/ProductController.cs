using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject the DbContext
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Product
        //[HttpPost]
        //public IActionResult AddProduct([FromBody] Product product)
        //{
        //    if (product == null)
        //    {
        //        return BadRequest("Product cannot be null.");
        //    }

        //    // Add the new product to the DbContext
        //    _context.Products.Add(product);  // Using the DbSet<Product> directly
        //    _context.SaveChanges();

        //    // Return the created product with a status code of 201 (Created)
        //    return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        //}

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            // Don't set the Id, let the database handle it (auto-incremented)
            _context.Products.Add(product);
            _context.SaveChanges();

            // Return the created product with a status code of 201 (Created)
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }



        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();  // Fetch all products from the DbContext
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Update the fields of the existing product
            existingProduct.Description = product.Description;
            existingProduct.Image = product.Image;
            existingProduct.Price = product.Price;
            existingProduct.ShippingCost = product.ShippingCost;

            _context.SaveChanges();
            return NoContent();  // No content as response for a successful update
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();  // No content as response for a successful delete
        }
    }
}
