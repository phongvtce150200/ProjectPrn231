using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITestRepository
    {
        List<Test> GetAllTest();
        Test GetTestById(int id);
        void CreateTest(Test t);
        void UpdateTest(Test t);
        void DeleteTest(Test t);
    }
}
