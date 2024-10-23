using ecommerceAPI.Model;

namespace ecommerceAPI.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerDetailById(int customerId);
        Task<List<Order>>GetOrdersDetailByCustomerId(string customerId);
    }
}
