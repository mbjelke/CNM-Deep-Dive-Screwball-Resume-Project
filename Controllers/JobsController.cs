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
    public class JobsController : Controller
    {
        private readonly ResumeContext _context;

        public JobsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: Jobs
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.Jobs
                .Include(j => j.Applicant)
                .Include(j => j.Accomplishments);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Applicant)
                //.Include(j=>j.Accomplishments)
                .SingleOrDefaultAsync(m => m.JobID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
    
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantID,Company,Title,Location,FromYear,ToYear,IsCurrent,Description")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", job.ApplicantID);
            return View(job);
        }

        //TODO Fix Edit on all controllers
        // GET: Jobs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", job.ApplicantID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantID,Company,Title,Location,FromYear,ToYear,IsCurrent,Description")] Job job)
        {
            if (id != job.JobID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    job.JobID = id;
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", job.ApplicantID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Applicant)
                .SingleOrDefaultAsync(m => m.JobID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobID == id);
        }
    }
}
