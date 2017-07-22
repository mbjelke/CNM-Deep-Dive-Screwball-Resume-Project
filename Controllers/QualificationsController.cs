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
    public class QualificationsController : Controller
    {
        private readonly ResumeContext _context;

        public QualificationsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: Qualifications
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.Qualifications.Include(q => q.Applicant);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Qualifications/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications
                .Include(q => q.Applicant)
                .SingleOrDefaultAsync(m => m.QualificationID == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // GET: Qualifications/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantID,Skill")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualification);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", qualification.ApplicantID);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications.SingleOrDefaultAsync(m => m.QualificationID == id);
            if (qualification == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", qualification.ApplicantID);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantID,Skill")] Qualification qualification)
        {
            //if (id != qualification.QualificationID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    qualification.QualificationID = id;
                    _context.Update(qualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationExists(qualification.QualificationID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", qualification.ApplicantID);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications
                .Include(q => q.Applicant)
                .SingleOrDefaultAsync(m => m.QualificationID == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qualification = await _context.Qualifications.SingleOrDefaultAsync(m => m.QualificationID == id);
            _context.Qualifications.Remove(qualification);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool QualificationExists(int id)
        {
            return _context.Qualifications.Any(e => e.QualificationID == id);
        }
    }
}
