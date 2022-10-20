using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private IDoctorRepository _doctorRepository = new DoctorRepository();

        // GET: api/<DoctorController>
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetDoctor()
        {
            var list = _doctorRepository.GetAllDoctor();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {

            var d = _doctorRepository.GetDoctorById(id);
            if (d == null)
            {
                return NotFound();
            }
            return Ok(d);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult CreateDoctor(Doctor d)
        {
            _doctorRepository.CreateDoctor(d);
            return Ok(d);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, Doctor d)
        {
            var iTmp = _doctorRepository.GetDoctorById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _doctorRepository.UpdateDoctor(d);
            return Ok(d);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var iTmp = _doctorRepository.GetDoctorById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _doctorRepository.DeleteDoctor(iTmp);
            return Ok(iTmp);
        }
    }
}
