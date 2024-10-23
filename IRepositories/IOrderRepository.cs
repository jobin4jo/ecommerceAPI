using ecommerceAPI.DTO.Order.Response;
using ecommerceAPI.Model;

namespace ecommerceAPI.IRepositories
{
    public interface IOrderRepository
    {
        Task<CustomerOrderFinalResponseDTO> GetCustomerOrder(string email,int customerId);
        Task<List<OrderItems>>GetOrderDetailsByorderId(int orderId);    
    }
}
