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

        public async Task<ProductDto> GetItem(int id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/api/Product/GetItem/{id}");
                //Check if response is successful
                if(response.IsSuccessStatusCode)
                { 
                    //Check if no content returned -> Return default value
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductDto); 
                    }

                    return await response.Content.ReadFromJsonAsync<ProductDto>();
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }
            }
            catch(Exception)
            {
                //Log Exception
                throw;
            }
        }
    }
}
