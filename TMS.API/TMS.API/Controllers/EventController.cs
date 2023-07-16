using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Repositories;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;
        //private readonly IMapper _mapper;

        public EventController()
        {
            eventRepository = new EventRepository();
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = eventRepository.GetAll();
            var eventsDTO = events.Select(e => new EventDto()
            {
                EventId = e.EventId,
                EventDescription = e.EventDescription,
                EventName = e.EventName,
                EventType = e.EventType?.EventTypeName ?? string.Empty,
                Venue = e.Venue?.VenueLocation ?? string.Empty
            });
            return Ok(eventsDTO);
        }

    }
}