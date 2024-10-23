using ecommerceAPI.DTO.Customer.Request;
using ecommerceAPI.IRepositories;
using ecommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository _orderRepository)
        {
            this._orderRepository = _orderRepository;
        }
        [HttpPost("CustomerOrder")]
        public async Task<ActionResult> GetOrderDetailByCustomer([FromBody] CustomerOrderRequestDTO customerOrderRequest)
        {
            try
            {
                var response = await _orderRepository.GetCustomerOrder(customerOrderRequest.mail,customerOrderRequest.CustomerId);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
