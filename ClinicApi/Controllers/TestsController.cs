using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController : ControllerBase
    {
        private ITestRepository _testRepository = new TestRepository();

        // GET: api/Tests
        [HttpGet]
        public ActionResult<IEnumerable<Test>> Gettests()
        {
            var t = _testRepository.GetAllTest();
            if (t == null)
            {
                return NoContent();
            }
            return Ok();
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        public ActionResult<Test> GetTestById(int id)
        {
            var test = _testRepository.GetTestById(id);

            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        // PUT: api/Tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateTest(int id, Test test)
        {
            var tTmp = _testRepository.GetTestById(id);
            if (tTmp == null)
            {
                return NotFound();
            }
            _testRepository.UpdateTest(test);
            return Ok(test);
        }

        // POST: api/Tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Test> CreateTest(Test test)
        {
            _testRepository.CreateTest(test);
            return Ok(test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            var tTmp = _testRepository.GetTestById(id);
            if (tTmp == null)
            {
                return NotFound();
            }
            _testRepository.DeleteTest(tTmp);
            return Ok(tTmp);
        }
    }
}
