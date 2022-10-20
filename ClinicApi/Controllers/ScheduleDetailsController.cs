using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using System.Collections.Generic;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleDetailsController : ControllerBase
    {
        private IScheduleDetailsRepository _ScheduleDetailsRepository = new ScheduleDetailsRepository();

        // GET: api/<InvoiceController>
        [HttpGet]
        public ActionResult<IEnumerable<ScheduleDetails>> GetScheduleDetails()
        {
            var schd = _ScheduleDetailsRepository.GetAllScheduleDetails();
            if (schd == null)
            {
                return NoContent();
            }
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(schd, jss);
            return Content(jsons, "application/json");
            //return Ok(schd);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ScheduleDetails>> GetScheduleDetailsByDocId(int id)
        {
            var schd = _ScheduleDetailsRepository.GetScheduleDetailsByDocId(id);
            if (schd == null)
            {
                return BadRequest();
            }
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(schd, jss);
            return Content(jsons, "application/json");
            //return Ok(schd);
        }

    }
}
