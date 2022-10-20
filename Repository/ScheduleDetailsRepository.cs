using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ScheduleDetailsRepository : IScheduleDetailsRepository
    {
        public List<ScheduleDetails> GetAllScheduleDetails() => ScheduleDetailsDAO.GetScheduleDetails();

        public List<ScheduleDetails> GetScheduleDetailsByDocId(int DocId) => ScheduleDetailsDAO.GetScheduleDetailsByDoctorId(DocId);
    }
}
