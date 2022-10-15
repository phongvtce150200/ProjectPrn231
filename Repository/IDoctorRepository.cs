using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAllDoctor();
        Doctor GetDoctorById(int id);
        void CreateDoctor(Doctor d);
        void UpdateDoctor(Doctor d);
        void DeleteDoctor(Doctor d);
    }
}
