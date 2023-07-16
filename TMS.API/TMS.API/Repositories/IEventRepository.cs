using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Task<Event> GetById(long id);

        int Add(Event @event);

        void Update(Event @event);

        void Delete(Event @event);
    }

}
