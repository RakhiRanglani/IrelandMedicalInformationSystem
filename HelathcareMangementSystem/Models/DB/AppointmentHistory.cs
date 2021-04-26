using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models.DB
{
    public partial class AppointmentHistory
    {
        public AppointmentHistory()
        {
            Patients = new HashSet<Patient>();
        }

        public int AppHistoryId { get; set; }
        public DateTime Appointmentdate { get; set; }
        public string MedicalCondition { get; set; }
        public int? DoctorId { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
