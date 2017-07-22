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
    public class ApplicantsController : Controller
    {
        private readonly ResumeContext _context;

        public ApplicantsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: Applicants
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applicants.ToListAsync());
        }

        // GET: Applicants/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var applicant = await _context.Applicants
                .Include(s => s.References)
                .Include(s => s.Educations)
                .Include(s => s.Certifications)
                .Include(s => s.Qualifications)
                .Include(s => s.Affiliations)
                .Include(s => s.Jobs)
                    .ThenInclude(j => j.Accomplishments)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);


            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: Applicants/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,MiddleInit,LastName,Phone,Email,Address1,Address2,City,State,Zip,Website,LinkedIn,Facebook,Twitter,ProfessionalStatement")] Applicant applicant)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    _context.Add(applicant);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log
                ModelState.AddModelError(" ", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                 .Include(s => s.References)
                 .Include(s => s.Educations)
                 .Include(s => s.Certifications)
                 .Include(s => s.Qualifications)
                 .Include(s => s.Affiliations)
                 .Include(s => s.Jobs)
                     .ThenInclude(j => j.Accomplishments)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(m => m.ID == id);

            //{
            //    return NotFound();
            //}
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,MiddleInit,LastName,Phone,Email,Address1,Address2,City,State,Zip,Website,LinkedIn,Facebook,Twitter,ProfessionalStatement")] Applicant applicant)

        {
            //if (id != applicant.ID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(applicant.ID))
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
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var applicant = await _context.Applicants
                .Include(s => s.References)
                .Include(s => s.Educations)
                .Include(s => s.Certifications)
                .Include(s => s.Qualifications)
                .Include(s => s.Affiliations)
                .Include(s => s.Jobs)
                    .ThenInclude(j => j.Accomplishments)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);



            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _context.Applicants.SingleOrDefaultAsync(m => m.ID == id);
            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.ID == id);
        }
    }
}
