using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScrewballResume.Data;
using ScrewballResume.Models;
using Microsoft.AspNetCore.Authorization;

namespace ScrewballResume.Controllers
{
    public class AffiliationsController : Controller
    {
        private readonly ResumeContext _context;

        public AffiliationsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: Affiliations
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.Affiliations.Include(a => a.Applicant);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Affiliations/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliation = await _context.Affiliations
                .Include(a => a.Applicant)
                .SingleOrDefaultAsync(m => m.AffiliationID == id);
            if (affiliation == null)
            {
                return NotFound();
            }

            return View(affiliation);
        }

        // GET: Affiliations/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
            return View();
        }

        // POST: Affiliations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantID,AffilOrg,Role,Type,From,To,AffilURL,IsCurrent")] Affiliation affiliation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(affiliation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", affiliation.ApplicantID);
            return View(affiliation);
        }

        // GET: Affiliations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliation = await _context.Affiliations.SingleOrDefaultAsync(m => m.AffiliationID == id);
            if (affiliation == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", affiliation.ApplicantID);
            return View(affiliation);
        }

        // POST: Affiliations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantID,AffilOrg,Role,Type,From,To,AffilURL,IsCurrent")] Affiliation affiliation)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    affiliation.AffiliationID = id;
                    _context.Update(affiliation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AffiliationExists(affiliation.AffiliationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", affiliation.ApplicantID);
            return View(affiliation);
        }

        // GET: Affiliations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliation = await _context.Affiliations
                .Include(a => a.Applicant)
                .SingleOrDefaultAsync(m => m.AffiliationID == id);
            if (affiliation == null)
            {
                return NotFound();
            }

            return View(affiliation);
        }

        // POST: Affiliations/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var affiliation = await _context.Affiliations.SingleOrDefaultAsync(m => m.AffiliationID == id);
            _context.Affiliations.Remove(affiliation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AffiliationExists(int id)
        {
            return _context.Affiliations.Any(e => e.AffiliationID == id);
        }
    }
}
