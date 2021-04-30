using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.ViewModel
{
    [Keyless]
    public class PatientHistoryViewModel
    {
        [Display(Name = "Please Enter Patient Id")]
        
        public int PatientID { get; set; }
        public string PatientName { get; set; }

        public int PhoneNumber { get; set; }

        public double PatientWeight { get; set; }
        public string Gender { get; set; }

        public double Height { get; set; }

        public string CovidFlag { get; set; }

        public string EmailID { get; set; }

        public int Age { get; set; }

        public string DoctorName { get; set; }

        public DateTime Appointmentdate { get; set; }

        public string MedicalCondition { get; set; }

        public string SpecialtyDescription { get; set; }
        

        public List<PatientHistoryViewModel> patientlist { get; set; }

    }


}

