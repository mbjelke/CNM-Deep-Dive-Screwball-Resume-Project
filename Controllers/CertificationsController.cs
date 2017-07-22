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
    public class CertificationsController : Controller
    {
        private readonly ResumeContext _context;

        public CertificationsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: Certifications
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.Certifications.Include(c => c.Applicant);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Certifications/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .Include(c => c.Applicant)
                .SingleOrDefaultAsync(m => m.CertificationID == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // GET: Certifications/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
            return View();
        }

        // POST: Certifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantID,CertName,CertAuthority,LicenseNum,From,To,IsEternal,CertURL")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certification);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", certification.ApplicantID);
            return View(certification);
        }

        // GET: Certifications/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.SingleOrDefaultAsync(m => m.CertificationID == id);
            if (certification == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", certification.ApplicantID);
            return View(certification);
        }

        // POST: Certifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantID,CertName,CertAuthority,LicenseNum,From,To,IsEternal,CertURL")] Certification certification)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    certification.CertificationID = id;
                    _context.Update(certification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationExists(certification.CertificationID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", certification.ApplicantID);
            return View(certification);
        }

        // GET: Certifications/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .Include(c => c.Applicant)
                .SingleOrDefaultAsync(m => m.CertificationID == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // POST: Certifications/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certification = await _context.Certifications.SingleOrDefaultAsync(m => m.CertificationID == id);
            _context.Certifications.Remove(certification);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CertificationExists(int id)
        {
            return _context.Certifications.Any(e => e.CertificationID == id);
        }
    }
}
