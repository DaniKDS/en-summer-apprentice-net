using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)

        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var OrderDto = _mapper.Map<List<OrderDto>>(orders);

            return Ok(OrderDto);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(long id)
        {
            var order =await _orderRepository.GetById(id);
            var orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }


        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> patchOrder(OrderPatchDto orderPatchDto)
        {
            try
            {
                var orderEntity = await _orderRepository.GetById(orderPatchDto.OrderId);
                if (orderEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(orderPatchDto, orderEntity);
                _orderRepository.Update(orderEntity);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var orderEntity = await _orderRepository.GetById(id);
                if (orderEntity == null)
                {

                    return NotFound();
                }

                _orderRepository.Delete(orderEntity);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
