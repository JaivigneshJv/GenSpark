using ClinicManagementBLLibrary.Exceptions;
using ClinicManagementDALLibrary;
using ClinicManagementModelLibrary;


namespace ClinicManagementBLLibrary
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<int, Appointment> _appointmentRepository;
        private IRepository<int, Appointment> @object;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public AppointmentService(IRepository<int, Appointment> @object)
        {
            this.@object = @object;
        }

        public int AddAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new AppointmentConflictException("Appointment details are null.");
            }

            Appointment added = _appointmentRepository.Add(appointment);
            return added != null ? added.Id : -1;
        }

        public Appointment DeleteAppointment(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.Get(id);
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new AppointmentConflictException("Appointment details are null.");
            }
            return _appointmentRepository.Update(appointment);
        }
    }
}
