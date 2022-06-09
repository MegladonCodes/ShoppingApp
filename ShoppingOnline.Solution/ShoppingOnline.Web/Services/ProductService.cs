using ShopOnline.Models.Dtos;
using ShoppingOnline.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ShoppingOnline.Web.Services
{
    public class ProductService : IProductService
    {
        //Inject an HttpClient obj to perform API access
        private readonly HttpClient httpClient;

        public ProductService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var products = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("/api/Product/GetItems");
                return products;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
