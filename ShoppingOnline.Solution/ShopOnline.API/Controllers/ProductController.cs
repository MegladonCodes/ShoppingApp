using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Entities;
using ShopOnline.API.Extentions;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository _productRepository)
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
                var products = await this.productRepository.GetItems();
                //Get categories associated with product by CategoryId
                var categories = await this.productRepository.GetCategories();

                if(products == null || categories == null)
                {
                    return NotFound();
                }
                else
                {
                    var ProductDtos = products.ConvertToDtoList(categories);
                    return Ok(ProductDtos);
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategories()
        {
            try
            {
                //Get categories associated with product by CategoryId
                var categories = await this.productRepository.GetCategories();
    
            if (categories == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(categories);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductDto>> GetItem(int Id)
        {
            try
            {
                //Get categories associated with product by CategoryId
                var item = await this.productRepository.GetItem(Id);

                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    //Get category associated with product by CategoryId
                    var category = await this.productRepository.GetCategory(item.CategoryId);

                    var ProductDtos = item.ConvertToDto(category);
                    return Ok(ProductDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductCategory>> GetCategory(int Id)
        {
            try
            {
                //Get categories associated with product by CategoryId
                var category = await this.productRepository.GetCategory(Id);

                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(category);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
