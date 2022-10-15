using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        public List<Doctor> GetAllDoctor() => DoctorDAO.GetDoctor();

        public Doctor GetDoctorById(int id) => DoctorDAO.FindDoctorById(id);

        public void CreateDoctor(Doctor d) => DoctorDAO.CreateDoctor(d);

        public void UpdateDoctor(Doctor d) => DoctorDAO.UpdateDoctor(d);

        public void DeleteDoctor(Doctor d) => DoctorDAO.DeleteDoctor(d);
    }
}
