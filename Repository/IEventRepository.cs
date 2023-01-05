using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEventRepository
    {
        List<Event> GetEvents();
        void AddEvent(Event evnt);
        void UpdateEvent(Event evnt);
        void RemoveEvent(Event evnt);
        Event FindEventById(int id);    
    }
}
