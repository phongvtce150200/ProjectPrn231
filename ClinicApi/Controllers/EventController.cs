using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections;
using System.Collections.Generic;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventRepository _eventRepository = new EventRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            var list = _eventRepository.GetEvents();
            if(list == null)
            {
                return NoContent();
            }
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddEvent(Event evnt)
        {
            _eventRepository.AddEvent(evnt);
            return Ok(evnt);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(Event evnt)
        {
            var iTmp = _eventRepository.FindEventById(evnt.Id);
            if (iTmp == null)
                return NotFound();
            _eventRepository.UpdateEvent(evnt);
            return Ok(evnt);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var iTmp = _eventRepository.FindEventById(id);
            if (iTmp == null)
                return NotFound();
            _eventRepository.RemoveEvent(iTmp);
            return Ok(iTmp);
        }
    }
}
