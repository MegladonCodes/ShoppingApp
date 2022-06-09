using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShoppingOnline.Web.Services.Contracts;

namespace ShoppingOnline.Web.Pages
{
    //Abstract the service-calling code using this class
    public class ProductsBase : ComponentBase
    {
        //Facilitate DI of IProductService
        [Inject]
        public IProductService ProductService { get; set; }
        //Collection of ProductDto objects exposed to Blazor component
        public IEnumerable<ProductDto> Products { get; set; }

        //Retrieve data when component is first invoked
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();
        }
    }
}
