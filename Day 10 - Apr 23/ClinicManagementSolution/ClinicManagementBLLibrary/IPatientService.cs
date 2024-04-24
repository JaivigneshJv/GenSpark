using ClinicManagementModelLibrary;

namespace ClinicManagementBLLibrary
{
    public interface IPatientService
    {
        int AddPatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        Patient UpdatePatient(Patient patient);
        Patient DeletePatient(int id);
    }
}
