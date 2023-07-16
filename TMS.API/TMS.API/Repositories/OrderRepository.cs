using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public int Add(Order @order)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders.ToList();
            return orders;
        }

        public async Task<Order> GetById(long id)
        {
            var @order= _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefault();

            return @order;
        }

        public void Update(Order @order)
        {
            throw new NotImplementedException();
        }
    }   

}
