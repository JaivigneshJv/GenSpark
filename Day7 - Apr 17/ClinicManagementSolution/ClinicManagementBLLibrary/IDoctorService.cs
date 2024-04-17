using ClinicManagementModelLibrary;

namespace ClinicManagementBLLibrary
{
    public interface IDoctorService
    {
        int AddDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        List<Doctor> GetAllDoctors();
        Doctor UpdateDoctor(Doctor doctor);
        Doctor DeleteDoctor(int id);
    }
}
