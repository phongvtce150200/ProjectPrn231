using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EventRepository : IEventRepository
    {
        public List<Event> GetEvents() => EventDAO.GetEvents();
        public void AddEvent(Event evnt) => EventDAO.AddEvent(evnt);
        public void UpdateEvent(Event evnt) => EventDAO.UpdateEvent(evnt);
        public void RemoveEvent(Event evnt) => EventDAO.DeleteEvent(evnt);
        public Event FindEventById(int id) => EventDAO.FindEventById(id);
        
    }
}
