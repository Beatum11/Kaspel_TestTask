using BooksStore.Data;
using BooksStore.DTOs.Orders;
using BooksStore.Repositories.Books;
using BooksStore.Repositories.Orders;
using BooksStore.Services;
using BooksStore.Services.Books;
using BooksStore.Services.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Setup

        private readonly IOrdersRepository ordersRepository;
        
        public OrdersController(IOrdersRepository _ordersRepository)
        {
            ordersRepository = _ordersRepository;
        }

        #endregion

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetOrderDTO>>>> GetOrders
                                                                            (string? orderNum, 
                                                                             DateTime? date)
        {
            var res = await ordersRepository.GetOrders(orderNum, date);
            return res.Success ? Ok(res) : NotFound(res.Message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> GetOrder(int id)
        {
            var res = await ordersRepository.GetOrder(id);
            return res.Success ? Ok(res) : NotFound(res.Message);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(AddOrderDTO order)
        {
            var res = await ordersRepository.CreateOrder(order);
            return res.Success ? Ok(res) : BadRequest(res.Message);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(UpdateOrderDTO order)
        {
            var res = await ordersRepository.UpdateOrder(order);
            return res.Success ? Ok(res) : BadRequest(res.Message);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await ordersRepository.DeleteOrder(id);
            return Ok();
        }
    }
}
