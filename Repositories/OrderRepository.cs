using AutoMapper;
using Dapper;
using ecommerceAPI.Common;
using ecommerceAPI.DBConfiguration;
using ecommerceAPI.DTO.Customer.Response;
using ecommerceAPI.DTO.Order.Response;
using ecommerceAPI.IRepositories;
using ecommerceAPI.Model;
using System.Data;

namespace ecommerceAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperDbConnection dbConnection;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public OrderRepository(DapperDbConnection dbConnection, ICustomerRepository _customerRepository, IMapper mapper)
        {
            this.dbConnection = dbConnection;
            this._customerRepository = _customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerOrderFinalResponseDTO> GetCustomerOrder(string email, int customerId)
        {
            var customerRespone = await _customerRepository.GetCustomerDetailById(customerId);
            if (customerRespone == null || !customerRespone.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            var customerOrderDetail = await _customerRepository.GetOrdersDetailByCustomerId(customerId.ToString());
            if (customerOrderDetail == null)
            {
                return new CustomerOrderFinalResponseDTO
                {
                    customer = new CustomerResponseDTO { FirstName = customerRespone.FirstName, LastName = customerRespone.LastName }
                };
            }
        
            var finalResponse =await  CustomerOrderResponse(customerRespone, customerOrderDetail);
            return finalResponse;
        }

        public async Task<List<OrderItems>> GetOrderDetailsByorderId(int orderId)
        {
            var query = ECProcedure.SP_ORDER_ITEMS_BY_ORDER_ID;
            using var con = dbConnection.CreateConnection();
            var response = await con.QueryAsync<OrderItems>(query,new { OrderId = orderId },commandType: CommandType.StoredProcedure);
            return response.ToList();
        }
        public async Task<CustomerOrderFinalResponseDTO> CustomerOrderResponse(Customer customerResponse, List<Order> customerOrderDetail)
        {
            var orders = new List<CustomerOrderResponseDTO>();

            foreach (var order in customerOrderDetail)
            {
                var orderItems = await GetOrderDetailsByorderId(order.OrderId); 

                var orderDto = new CustomerOrderResponseDTO
                {
                    OrderNumber = order.OrderId,
                    OrderDate = order.OrderDate,
                    DeliveryAddress = $"{customerResponse.HouseNo}, {customerResponse.Street}, {customerResponse.Town}, {customerResponse.PostCode}",
                    DeliveryExpected = order.DeliveredExcepted,
                    OrderItems = _mapper.Map<List<OrderItemResponseDTO>>(orderItems) 
                };

                orders.Add(orderDto);
            }

            return new CustomerOrderFinalResponseDTO
            {
                customer = new CustomerResponseDTO
                {
                    FirstName = customerResponse.FirstName,
                    LastName = customerResponse.LastName
                },
                order = orders
            };
        }

    }
}
