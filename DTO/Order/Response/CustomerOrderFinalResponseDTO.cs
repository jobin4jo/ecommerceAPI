using ecommerceAPI.DTO.Customer.Response;

namespace ecommerceAPI.DTO.Order.Response
{
    public class CustomerOrderFinalResponseDTO
    {
        public CustomerResponseDTO customer { get;set; }   
        public List<CustomerOrderResponseDTO> order { get;set; }
    }
}
