using Dapper;
using ecommerceAPI.Common;
using ecommerceAPI.DBConfiguration;
using ecommerceAPI.IRepositories;
using ecommerceAPI.Model;
using System.Data;

namespace ecommerceAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperDbConnection dbConnection;
        public CustomerRepository(DapperDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public async  Task<Customer> GetCustomerDetailById(int customerId)
        {
            var query = ECProcedure.SP_GET_CUSTOMER_DETAIL_BY_ID;
            using var con = dbConnection.CreateConnection();
            var response = await con.QueryAsync<Customer>(query, new { CustomerId = customerId }, commandType: CommandType.StoredProcedure);
            return response.First();
        }

        public async Task<List<Order>> GetOrdersDetailByCustomerId(string customerId)
        {
            var query = ECProcedure.SP_GET_ORDER_BY_CUSTOMER_ID;
            using var con = dbConnection.CreateConnection();
            var response = await con.QueryAsync<Order>(query, new { CustomerId = customerId }, commandType: CommandType.StoredProcedure);
            return response.ToList();
        }
    }
}
