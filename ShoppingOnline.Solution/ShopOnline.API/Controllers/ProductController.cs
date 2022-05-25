using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Extentions;
using ShopOnline.API.Repositories;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductRepository productRepository;

        public ProductController(ProductRepository _productRepository)
        {
            this.productRepository = _productRepository;
        }

        //Action Result -> Returns data and response codes
        //Return data formatted by the DTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItem();
                //Get categories associated with product by CategoryId
                var categories = await this.productRepository.GetCategories();

                if(products == null || categories == null)
                {
                    return NotFound();
                }
                else
                {
                    var ProductDtos = products.ConvertToDto(categories);
                    return Ok(ProductDtos);
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
