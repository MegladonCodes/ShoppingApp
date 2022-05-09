namespace ShopOnline.API.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        //FK Reference to Cart -> 1 Cart Many CartItems
        public int CartId { get; set; }
        //FK Reference to Product -> 1 CartItem Many Products
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
