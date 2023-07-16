using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Mvc;
using TMS.API.Models.Dto;
using TMS.API.Repositories;

namespace TMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController: ControllerBase
    {

        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();
            var ordersDTO = orders.Select(e => new OrderDto()
            {
                OrderId = e.OrderId,
                CustomerId = e.CustomerId ?? 0,
                TicketCategoryId = e.TicketCategoryId ?? 0,
                OrderedAt = e.OrderedAt,
                NumberOfTickets = e.NumberOfTickets ?? 0,
                TicketCategory = e.TicketCategory,
                Customer = e.Customer
            });
            return Ok(ordersDTO);
        }
    }
}
