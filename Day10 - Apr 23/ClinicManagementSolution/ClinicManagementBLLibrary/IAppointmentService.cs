using ClinicManagementModelLibrary;

namespace ClinicManagementBLLibrary
{
    public interface IAppointmentService
    {
        int AddAppointment(Appointment appointment);
        Appointment GetAppointmentById(int id);
        List<Appointment> GetAllAppointments();
        Appointment UpdateAppointment(Appointment appointment);
        Appointment DeleteAppointment(int id);
    }
}
