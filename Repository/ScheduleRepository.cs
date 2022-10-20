using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        public List<Schedule> GetScheduleByDocId(int DocId) => ScheduleDAO.GetScheduleByDocId(DocId);
    }
}
