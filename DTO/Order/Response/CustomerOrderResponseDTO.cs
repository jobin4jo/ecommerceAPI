namespace ecommerceAPI.DTO.Order.Response
{
    public class CustomerOrderResponseDTO
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItemResponseDTO> OrderItems { get; set; }
        public DateTime DeliveryExpected { get; set; }
    }
}
