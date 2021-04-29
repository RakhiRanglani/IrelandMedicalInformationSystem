using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.ViewModel
{

    [Keyless]
    public class MedicalCardViewModel
    {
        [Display(Name="Medical Card Number")]
        public int MedicalCardId { get; set; }

        public string AccessLevel { get; set; }
       
    }
}
