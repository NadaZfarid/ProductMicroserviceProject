using Microsoft.AspNetCore.Mvc;
using ProductMicroserviceProject.Models;
using ProductMicroserviceProject.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroserviceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAll()
        {
           List<Product> products = productRepository.GetAllProduct();
            if (products!= null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{ProductId}")]
        public IActionResult GetById(int ProductId)
        {
            Product product = productRepository.GetProductById(ProductId);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product != null)
            {
                productRepository.AddProduct(product);
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if(id==product.id)
            {
                productRepository.UpdateProduct(product);
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepository.DeleteProduct(id);
        }
    }
}
