namespace ecommerceAPI.DTO.Order.Response
{
    public class OrderItemResponseDTO
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
    }
}
