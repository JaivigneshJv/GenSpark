using ClinicManagementDALLibrary;
using ClinicManagementModelLibrary;
using ClinicManagementBLLibrary.Exceptions;

namespace ClinicManagementBLLibrary
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        public int AddPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new PatientNotFoundException("Patient details are null.");
            }

          
            Patient added = _patientRepository.Add(patient);
            return added != null ? added.Id : -1;
        }

        public Patient DeletePatient(int id)
        {
            Patient patient = _patientRepository.Get(id);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {id} not found.");
            }

            return _patientRepository.Delete(id);
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatientById(int id)
        {
            Patient patient = _patientRepository.Get(id);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {id} not found.");
            }

            return patient;
        }

        public Patient UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new PatientNotFoundException("Patient details are null.");
            }

            return _patientRepository.Update(patient);
        }
    }
}
