using ShopOnline.API.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Extentions
{
    //Generate DTO Objects from the relevant information passed in using LINQ
    public static class DtoConversions
    {
        //Converts Product & Category Data from Database into DTO Object
        public static IEnumerable<ProductDto> ConvertToDtoList(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products join productCategory in productCategories on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name,
                    }).ToList();
        }

        public static ProductDto ConvertToDto(this Product products, ProductCategory productCategory)
        {
            return ( new ProductDto
                    {
                        Id = products.Id,
                        Name = products.Name,
                        Description = products.Description,
                        ImageURL = products.ImageURL,
                        Price = products.Price,
                        Qty = products.Qty,
                        CategoryId = products.CategoryId,
                        CategoryName = productCategory.Name,
                    });
        }
    }
}
