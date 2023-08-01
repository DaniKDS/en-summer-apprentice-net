using Microsoft.EntityFrameworkCore;
using TMS.API.Exceptions;
using static Microsoft.EntityFrameworkCore.EntityState;
using Microsoft.Extensions.DependencyInjection;
using TMS.API.Models;
using TMS.API.Models.Dto;

namespace TMS.API.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public OrderDto Add(OrderDto orderDto)
        {
            var order = _dbContext.Add(orderDto);
            _dbContext.SaveChanges();
            return order.Entity;
        }

        public void Delete(Order order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders.ToList();
            return orders;
        }

        public async Task<Order> GetById(long id)
        {
            var orders= await _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefaultAsync();
            return orders;

        }

        public void Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }   

}
