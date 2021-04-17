using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HealthcareMangementSystem.Models;

namespace HealthcareMangementSystem.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly HealthcareMangementSystem.Models.IrelandHospitalContext _context;

        public CreateModel(HealthcareMangementSystem.Models.IrelandHospitalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressId"] = new SelectList(_context.PatientAddresses, "AddressId", "AdressLine1");
        ViewData["AppHistoryId"] = new SelectList(_context.AppointmentHistories, "AppHistoryId", "AppHistoryId");
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
