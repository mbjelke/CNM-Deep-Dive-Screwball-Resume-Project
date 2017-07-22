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
    public class AccomplishmentsController : Controller
    {
        private readonly ResumeContext _context;

        public AccomplishmentsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: Accomplishments
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.Accomplishments.Include(a => a.Job).ThenInclude(j =>j.Applicant);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Accomplishments/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishments
                .Include(a => a.Job)
                .SingleOrDefaultAsync(m => m.AccomplishmentID == id);
            if (accomplishment == null)
            {
                return NotFound();
            }

            return View(accomplishment);
        }

        // GET: Accomplishments/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "Company");
            return View();
        }

        // POST: Accomplishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobID,Accomp")] Accomplishment accomplishment)
        {
            if (ModelState.IsValid)
            {

                _context.Add(accomplishment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "Company", accomplishment.JobID);
            return View(accomplishment);
        }

        // GET: Accomplishments/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishments.SingleOrDefaultAsync(m => m.AccomplishmentID == id);
            if (accomplishment == null)
            {
                return NotFound();
            }
            ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "Company", accomplishment.JobID);
            return View(accomplishment);
        }

        // POST: Accomplishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccomplishmentID,JobID,Accomp")] Accomplishment accomplishment)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    accomplishment.AccomplishmentID = id;
                    _context.Update(accomplishment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccomplishmentExists(accomplishment.AccomplishmentID))
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
            ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "Company", accomplishment.JobID);
            return View(accomplishment);
        }

        // GET: Accomplishments/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishments
                .Include(a => a.Job)
                .SingleOrDefaultAsync(m => m.AccomplishmentID == id);
            if (accomplishment == null)
            {
                return NotFound();
            }

            return View(accomplishment);
        }

        // POST: Accomplishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accomplishment = await _context.Accomplishments.SingleOrDefaultAsync(m => m.AccomplishmentID == id);
            _context.Accomplishments.Remove(accomplishment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccomplishmentExists(int id)
        {
            return _context.Accomplishments.Any(e => e.AccomplishmentID == id);
        }
    }
}
