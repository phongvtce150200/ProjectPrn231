using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;


namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientRepository _patientRepository = new PatientRepository();

        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetMedicine()
        {
            var list = _patientRepository.GetAllPatient();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {

            var p = _patientRepository.GetPatientById(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // POST api/<PatientController>
        [HttpPost]
        public IActionResult CreatePatient(Patient p)
        {
            _patientRepository.CreatePatient(p);
            return Ok(p);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient p)
        {
            var iTmp = _patientRepository.GetPatientById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _patientRepository.UpdatePatient(p);
            return Ok(p);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var iTmp = _patientRepository.GetPatientById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _patientRepository.DeletePatient(iTmp);
            return Ok(iTmp);
        }
    }
}
