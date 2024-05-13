using System;
using System.Collections.Generic;

namespace DoctorAppointmentDALLibrary.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }

        public Appointment(int? doctorId, int? patientId, DateTime dateTime)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            DateTime = dateTime;
        }

        public Appointment()
        {
            DoctorId = null;
            PatientId = null;
            DateTime = null;

        }

        public override string ToString()
        {
            return "Appointment ID : " + Id
                + "\nDoctor : " + DoctorId
                + "\nPatient : " + PatientId
                + "\nAppointment Date  : " + DateTime + "\n";

        }
       
    }
}
