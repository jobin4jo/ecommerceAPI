using ecommerceAPI.Model;

namespace ecommerceAPI.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductList();
    }
}
