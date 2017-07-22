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
    public class ReferencesController : Controller
    {
        private readonly ResumeContext _context;

        public ReferencesController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: References
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.References.Include(r => r.Applicant);
            return View(await resumeContext.ToListAsync());
        }

        // GET: References/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .Include(r => r.Applicant)
                .SingleOrDefaultAsync(m => m.ReferenceID == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: References/Create
        [Authorize]
        public IActionResult Create()
        {
            // THIS IS WHAT adding a controller "gave" me - I changed Address1 to FullName
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");

            //But this is what the tutorial indicates should be here? https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data#customize-the-create-and-edit-pages-for-courses
            //PopulateApplicantsDropDownList();
         
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        //I removed Reference ID 
        public async Task<IActionResult> Create([Bind("ApplicantID,FirstName,MiddleInit,LastName,Phone,Email,ReferenceDesc")] Reference reference
            //,int ApplicantID
            )
        {
            if (ModelState.IsValid)
            {

                // currentApplicant = _context.Applicants.Where(a => a.ID == ApplicantID).FirstOrDefault();
                /*reference.ApplicantID = ApplicantID;*/
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //THIS IS WHAT adding a controller "gave" me - I changed Address1 to FullName
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", reference.ApplicantID);

            //But this is what the tutorial indicates should be here? https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data#customize-the-create-and-edit-pages-for-courses
            //PopulateApplicantDropDownList(reference.ApplicantID);
            return View(reference);
        }

        // GET: References/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceID == id);
            if (reference == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", reference.ApplicantID);
            return View(reference);
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,MiddleInit,LastName,Phone,Email,ReferenceDesc")] Reference reference, int ApplicantID)
        {
            //if (id != reference.ReferenceID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                    reference.ReferenceID = id;
                    reference.ApplicantID = ApplicantID;
                    _context.Add(reference);
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", reference.ApplicantID);
            return View(reference);
        }

        // GET: References/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .Include(r => r.Applicant)
                .SingleOrDefaultAsync(m => m.ReferenceID == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: References/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceID == id);
            _context.References.Remove(reference);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReferenceExists(int id)
        {
            return _context.References.Any(e => e.ReferenceID == id);
        }
    }
}
