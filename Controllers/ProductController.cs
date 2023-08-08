using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var productList = productService.GetProductList();
            var response = new { success = true, message = "Products retrieved successfully", data = productList };
            return Ok(response);
            //return productList;
        }
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return productService.GetProductById(id);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var addedProduct = productService.AddProduct(product);
            if (AddProduct !=null)
            {
                var response = new { success = true, message = "Products added successfully", data = addedProduct };
                return Ok(response);
            }
            else
            {
                var response = new { success = true, message = "Failed to add Product", data = addedProduct };
                return BadRequest(response);
            }
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var updatedProduct = productService.UpdateProduct(product);
            if (AddProduct != null)
            {
                var response = new { success = true, message = "Products Update successfully", data = updatedProduct };
                return Ok(response);
            }
            else
            {
                var response = new { success = true, message = "Failed to add Product", data = updatedProduct };
                return BadRequest(response);
            }
            //return productService.UpdateProduct(product);
        }
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            return productService.DeleteProduct(id);
        }
    }
}
