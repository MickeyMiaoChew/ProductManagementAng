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
            try
            {
                var productList = productService.GetProductList();
                var response = new { success = true, message = "Products retrieved successfully", data = productList };
                return Ok(response);

            }
            catch (Exception ex)
            {

                var errorResponse = new { success = true, message = "Failed to add Product  :" + ex.Message, data = ex.Message };
                return BadRequest(errorResponse);

            }
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
            
            try
            {
                var addedProduct = productService.AddProduct(product);
                var response = new { success = true, message = "Products added successfully", data = addedProduct };
                return Ok(response);
            }
            catch (Exception ex)
            {
                
                var errorResponse = new { success = true, message = "Failed to add Product  :"+ex.Message , data = ex.Message };
                return BadRequest(errorResponse);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                var updatedProduct = productService.UpdateProduct(product);
                var response = new { success = true, message = "Products Update successfully", data = updatedProduct };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new { success = true, message = "Failed to add Product" + ex.Message, data = ex.Message };
                return BadRequest(errorResponse);
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
