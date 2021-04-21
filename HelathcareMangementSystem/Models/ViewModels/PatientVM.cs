using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMangementSystem.Models.ViewModels
{
    public class PatientVM
    {
        [Required]
        [Display(Name = "First Name")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string PatientLastName { get; set; }
    }
}
