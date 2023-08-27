using TMS.API.Models;
using TMS.API.Models.Dto;

namespace TMS.API.Repositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAll();

        public Task<Order> GetById(long id);

        public OrderDto Add(OrderDto orderDto);

        public void Update(Order order);

        public void Delete(Order order);
    }
}
