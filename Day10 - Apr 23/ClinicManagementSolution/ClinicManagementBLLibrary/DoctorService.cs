using ClinicManagementDALLibrary;
using ClinicManagementModelLibrary;
using ClinicManagementBLLibrary.Exceptions;

namespace ClinicManagementBLLibrary
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
        }

        public int AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new DoctorNotFoundException("Doctor details are null.");
            }


            Doctor added = _doctorRepository.Add(doctor);
            return added != null ? added.Id : -1;
        }

        public Doctor DeleteDoctor(int id)
        {
            Doctor doctor = _doctorRepository.Get(id);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {id} not found.");
            }

            return _doctorRepository.Delete(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetDoctorById(int id)
        {
            Doctor doctor = _doctorRepository.Get(id);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {id} not found.");
            }

            return doctor;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new DoctorNotFoundException("Doctor details are null.");
            }

            return _doctorRepository.Update(doctor);
        }
    }
}
