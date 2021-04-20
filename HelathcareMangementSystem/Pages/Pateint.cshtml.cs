using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthcareMangementSystem.Models.DB;

namespace HealthcareMangementSystem.Pages
{
    public class PateintModel : PageModel
    {
        private readonly HealthcareMangementSystem.Models.DB.IrelandHospitalContext _context;

        public PateintModel(HealthcareMangementSystem.Models.DB.IrelandHospitalContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients
                .Include(p => p.Address)
                .Include(p => p.AppHistory).FirstOrDefaultAsync(m => m.PatientId == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
