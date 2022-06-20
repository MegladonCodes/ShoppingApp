using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShoppingOnline.Web.Services.Contracts;

namespace ShoppingOnline.Web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int id { get; set; }
        public ProductDto product { get; set; }
        public string errorMessage { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                product = await ProductService.GetItem(id);
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}
