using ClinicManagementAPI.Models;
namespace ClinicManagementAPI.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> UpdateDoctorExperience(int id, int experience);
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialty(string specialty);
    }
}
