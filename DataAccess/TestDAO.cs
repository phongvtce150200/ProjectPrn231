using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TestDAO
    {
        public static List<Test> GetTest()
        {
            var listInvoice = new List<Test>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listInvoice = context.tests.ToList();
                    if (listInvoice.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listInvoice;
        }
        public static Test FindTestById(int testId)
        {
            Test i = new Test();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    i = context.tests.SingleOrDefault(x => x.TestId == testId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }
        public static void CreateTest(Test t)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.tests.Add(t);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateTest(Test t)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Test>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteTest(Test t)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.invoices.SingleOrDefault(c => c.TestId == t.TestId);
                    context.invoices.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
