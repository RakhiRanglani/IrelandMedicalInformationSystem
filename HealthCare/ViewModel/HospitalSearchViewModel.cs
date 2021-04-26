using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HealthCare.ViewModel
{
    public class HospitalSearchViewModel
    {
      
            [Key]
            public string HospitalName { get; set; }
            public string HospitalType { get; set; }
            public string City { get; set; }
            public string EIRCode { get; set; }
            public string County { get; set; }

             public List<HospitalSearchViewModel> Hospitallist { get; set; }

    }


}

