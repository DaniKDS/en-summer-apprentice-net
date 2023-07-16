using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Task<Order> GetById(long id);

        int Add(Order @order);

        void Update(Order @order);

        void Delete(Order @order);
    }
}
