using ecommerceAPI.Common;
using ecommerceAPI.DBConfiguration;
using ecommerceAPI.IRepositories;
using ecommerceAPI.Model;
using System.Data;
using Dapper;
namespace ecommerceAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DapperDbConnection dbConnection;
    public ProductRepository(DapperDbConnection dbConnection)
    {
        this.dbConnection = dbConnection;
    }

    public async Task<List<Product>> GetAllProductList()
    {
        var query = ECProcedure.SP_GET_ALL_PRODUCTS;
        using var con = dbConnection.CreateConnection();
        var response = await con.QueryAsync<Product>(query, commandType: CommandType.StoredProcedure);

        return response.ToList();
    }
}
