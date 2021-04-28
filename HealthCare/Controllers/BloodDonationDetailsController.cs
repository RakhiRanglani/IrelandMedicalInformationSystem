using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthCare.Models;
using HealthCare.ViewModel;

namespace HealthCare.Controllers
{
    public class BloodDonationDetailsController : Controller
    {
        private readonly IrelandHospitalContext _context;

        public BloodDonationDetailsController(IrelandHospitalContext context)
        {
            _context = context;
        }

        // GET: BloodDonationDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblBloodDonationDetails.ToListAsync());
        }

        // GET: BloodDonationDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBloodDonationDetail = await _context.TblBloodDonationDetails
                .FirstOrDefaultAsync(m => m.BloodDonationId == id);
            if (tblBloodDonationDetail == null)
            {
                return NotFound();
            }

            return View(tblBloodDonationDetail);
        }

        // GET: BloodDonationDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodDonationDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BloodDonationId,HospitalId,EventDate,BloodGroupDetails")] TblBloodDonationDetail tblBloodDonationDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBloodDonationDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBloodDonationDetail);
        }

        // GET: BloodDonationDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBloodDonationDetail = await _context.TblBloodDonationDetails.FindAsync(id);
            if (tblBloodDonationDetail == null)
            {
                return NotFound();
            }
            return View(tblBloodDonationDetail);
        }

        // POST: BloodDonationDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BloodDonationId,HospitalId,EventDate,BloodGroupDetails")] TblBloodDonationDetail tblBloodDonationDetail)
        {
            if (id != tblBloodDonationDetail.BloodDonationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBloodDonationDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBloodDonationDetailExists(tblBloodDonationDetail.BloodDonationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblBloodDonationDetail);
        }

        // GET: BloodDonationDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBloodDonationDetail = await _context.TblBloodDonationDetails
                .FirstOrDefaultAsync(m => m.BloodDonationId == id);
            if (tblBloodDonationDetail == null)
            {
                return NotFound();
            }

            return View(tblBloodDonationDetail);
        }

        // POST: BloodDonationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBloodDonationDetail = await _context.TblBloodDonationDetails.FindAsync(id);
            _context.TblBloodDonationDetails.Remove(tblBloodDonationDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBloodDonationDetailExists(int id)
        {
            return _context.TblBloodDonationDetails.Any(e => e.BloodDonationId == id);
        }
        [HttpGet]
        public IActionResult OrganDonationDetail(OrganDonationViewModel model)
        {
            
            model.OrganDetailslist = _context.GetOrganInformation.FromSqlInterpolated($"GetOrganData").ToList();
            return View(model);

        }
    }
}
