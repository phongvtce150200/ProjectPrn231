using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EventDAO
    {
        public static List<Event> GetEvents()
        {
            var listEvents = new List<Event>();
            try
            {
                using var context = new ApplicationDbContext();
                listEvents = context.events.ToList();
                if (listEvents.Count == 0)
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listEvents;
        }

        public static void AddEvent(Event evnt)
        {
            try
            {
                using var context = new ApplicationDbContext();
                context.events.Add(evnt);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateEvent(Event evnt)
        {
            try
            {
                using var context = new ApplicationDbContext();
                context.Entry<Event>(evnt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteEvent(Event evnt)
        {
            try
            {
                using var context = new ApplicationDbContext();
                context.Remove(evnt);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Event FindEventById(int id)
        {
            Event evnt = new();
            try
            {
                using var context = new ApplicationDbContext();
                evnt = context.events.Find(id);

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return evnt;
        }
    }
}
