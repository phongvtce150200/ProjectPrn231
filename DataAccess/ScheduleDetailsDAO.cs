using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ScheduleDetailsDAO
    {
        public static List<ScheduleDetails> GetScheduleDetails()
        {
            var listScheduleDetails = new List<ScheduleDetails>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listScheduleDetails = context.ScheduleDetails.Include(x => x.Schedule).ToList();
                    if (listScheduleDetails.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listScheduleDetails;
        }
        public static List<ScheduleDetails> GetScheduleDetailsByDoctorId(int DocId)
        {
            var listScheduleDetails = new List<ScheduleDetails>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listScheduleDetails = context.ScheduleDetails.Include(x => x.Schedule).Where(y => y.Schedule.DoctorId == DocId).ToList();
                    if (listScheduleDetails.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listScheduleDetails;
        }
    }
}
