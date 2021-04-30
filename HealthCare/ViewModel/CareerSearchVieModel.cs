using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.ViewModel
{
    [Keyless]
    public class CareerSearchVieModel
    {
        [Display(Name = "Hospital Name")]
        [Required]
        public string HospitalName { get; set; }

        public string JobAvailability { get; set; }

        public string JobDetails { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        public string County { get; set; }

        public List<CareerSearchVieModel> careerlist { get; set; }

    }


}

