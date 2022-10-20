using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;
using Microsoft.AspNetCore.Authorization;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrescriptionsController : ControllerBase
    {
        private IPrescriptionRepository _PrescriptionRepository = new PrescriptionRepository();
        // GET: api/Prescriptions
        [HttpGet]
        public ActionResult<IEnumerable<Prescription>> GetPrescriptions()
        {
            var p = _PrescriptionRepository.GetAllPrescription();
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id}")]
        public ActionResult<Prescription> GetPrescriptionById(int id)
        {
            var p = _PrescriptionRepository.GetPrescriptionById(id);

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // PUT: api/Prescriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdatePrescription(int id, Prescription p)
        {
            var Tmp = _PrescriptionRepository.GetPrescriptionById(id);
            if (Tmp == null)
            {
                return NotFound();
            }
            _PrescriptionRepository.UpdatePrescription(p);
            return Ok(p);
        }

        // POST: api/Prescriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Prescription> CreatePrescription(Prescription p)
        {
            _PrescriptionRepository.CreatePrescription(p);
            return Ok(p);
        }

        // DELETE: api/Prescriptions/5
        [HttpDelete("{id}")]
        public IActionResult DeletePrescription(int id)
        {
            var Tmp = _PrescriptionRepository.GetPrescriptionById(id);
            if (Tmp == null)
            {
                return NotFound();
            }
            _PrescriptionRepository.DeletePrescription(Tmp);
            return Ok(Tmp);
        }
    }
}
