using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week_Project;
using Week_Project.Data;
using Week_Project.Models;

namespace Week_Project.Controllers
{
    public class Doctor_DetailController : Controller
    {
        private readonly Week_ProjectContext _context;

        public Doctor_DetailController(Week_ProjectContext context)
        {
            _context = context;
        }

        // GET: Doctor_Detail
        public async Task<IActionResult> Index()
        {
              return View(await _context.Doctor_Details.ToListAsync());
        }

        // GET: Doctor_Detail/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Doctor_Details == null)
            {
                return NotFound();
            }

            var doctor_Detail = await _context.Doctor_Details
                .FirstOrDefaultAsync(m => m.Dr_id == id);
            if (doctor_Detail == null)
            {
                return NotFound();
            }

            return View(doctor_Detail);
        }

        // GET: Doctor_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dr_id,Dr_name,Dr_pofile,Dr_Number,begin_time,end_time")] Doctor_Detail doctor_Detail)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(doctor_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor_Detail);
        }

        // GET: Doctor_Detail/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Doctor_Details == null)
            {
                return NotFound();
            }

            var doctor_Detail = await _context.Doctor_Details.FindAsync(id);
            if (doctor_Detail == null)
            {
                return NotFound();
            }
            return View(doctor_Detail);
        }

        // POST: Doctor_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Dr_id,Dr_name,Dr_pofile,Dr_Number,begin_time,end_time")] Doctor_Detail doctor_Detail)
        {
            if (id != doctor_Detail.Dr_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Doctor_DetailExists(doctor_Detail.Dr_id))
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
            return View(doctor_Detail);
        }

        // GET: Doctor_Detail/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Doctor_Details == null)
            {
                return NotFound();
            }

            var doctor_Detail = await _context.Doctor_Details
                .FirstOrDefaultAsync(m => m.Dr_id == id);
            if (doctor_Detail == null)
            {
                return NotFound();
            }

            return View(doctor_Detail);
        }

        // POST: Doctor_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Doctor_Details == null)
            {
                return Problem("Entity set 'MyAppDataContext.Doctor_Details'  is null.");
            }
            var doctor_Detail = await _context.Doctor_Details.FindAsync(id);
            if (doctor_Detail != null)
            {
                _context.Doctor_Details.Remove(doctor_Detail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Doctor_DetailExists(string id)
        {
          return _context.Doctor_Details.Any(e => e.Dr_id == id);
        }
    }
}
