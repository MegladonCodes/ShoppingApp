using ShopOnline.Models.Dtos;

namespace ShoppingOnline.Web.Services.Contracts
{
    /*
     * Create services to wrap our API Call functionality
     */
    public interface IProductService
    {
        //Implement API Call method definitions
        Task<IEnumerable<ProductDto>> GetItems();
    }
}
