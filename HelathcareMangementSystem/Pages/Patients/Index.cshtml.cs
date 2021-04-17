using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthcareMangementSystem.Models;

namespace HealthcareMangementSystem.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly HealthcareMangementSystem.Models.IrelandHospitalContext _context;

        public IndexModel(HealthcareMangementSystem.Models.IrelandHospitalContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patients
                .Include(p => p.Address)
                .Include(p => p.AppHistory).ToListAsync();
        }
    }
}
