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
    public class EducationsController : Controller
    {
        private readonly ResumeContext _context;

        public EducationsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: Educations
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.Educations.Include(e => e.Applicant);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Educations/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Applicant)
                .SingleOrDefaultAsync(m => m.EducationID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Educations/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantID,OrgName,Location,From,To,isCurrent,DegreeAttained,ConcentrationIn")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", education.ApplicantID);
            return View(education);
        }

        // GET: Educations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.SingleOrDefaultAsync(m => m.EducationID == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", education.ApplicantID);
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantID,OrgName,Location,From,To,isCurrent,DegreeAttained,ConcentrationIn")] Education education)
        {
            if (id != education.EducationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    education.EducationID = id;
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.EducationID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", education.ApplicantID);
            return View(education);
        }

        // GET: Educations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Applicant)
                .SingleOrDefaultAsync(m => m.EducationID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Educations/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.SingleOrDefaultAsync(m => m.EducationID == id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.EducationID == id);
        }
    }
}
