using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ScheduleDAO
    {
        public static List<Schedule> GetScheduleByDocId(int DocId)
        {
            var listSchedule = new List<Schedule>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listSchedule = context.schedules.Include(x => x.ScheduleDetails)
                                                    .Include(y => y.ReservedSchedules)
                                                    .Include(z => z.Doctor)
                                                    .ToList();
                    if (listSchedule.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listSchedule;
        }

    }
}
