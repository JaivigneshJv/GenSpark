namespace ClinicManagementModelLibrary
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; } 
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Status { get; set; } = string.Empty;

        public Appointment( int doctorId, int patientId, DateTime dateTime, string? status)
        {
            //Id = -1;
            DoctorId = doctorId;
            PatientId = patientId;
            DateTime = dateTime;
            Status = status;
        }
    }
}
