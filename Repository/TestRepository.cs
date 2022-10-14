using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TestRepository : ITestRepository
    {
        public void CreateTest(Test t) => TestDAO.CreateTest(t);

        public void DeleteTest(Test t) => TestDAO.DeleteTest(t);

        public List<Test> GetAllTest() => TestDAO.GetTest();

        public Test GetTestById(int id) => TestDAO.FindTestById(id);

        public void UpdateTest(Test t) => TestDAO.UpdateTest(t);
    }
}
