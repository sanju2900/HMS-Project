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
    public class Admin_pgController : Controller
    {
        private readonly Week_ProjectContext _context;

        public Admin_pgController(Week_ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin_pg
        public async Task<IActionResult> Index()
        {
              return View(await _context.Admin_Pgs.ToListAsync());
        }

        // GET: Admin_pg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Admin_Pgs == null)
            {
                return NotFound();
            }

            var admin_pg = await _context.Admin_Pgs
                .FirstOrDefaultAsync(m => m.Admin_Id == id);
            if (admin_pg == null)
            {
                return NotFound();
            }

            return View(admin_pg);
        }

        // GET: Admin_pg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin_pg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Admin_Id,Admin_Name,Admin_Email,Admin_password")] Admin_pg admin_pg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin_pg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin_pg);
        }

        // GET: Admin_pg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Admin_Pgs == null)
            {
                return NotFound();
            }

            var admin_pg = await _context.Admin_Pgs.FindAsync(id);
            if (admin_pg == null)
            {
                return NotFound();
            }
            return View(admin_pg);
        }

        // POST: Admin_pg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Admin_Id,Admin_Name,Admin_Email,Admin_password")] Admin_pg admin_pg)
        {
            if (id != admin_pg.Admin_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin_pg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Admin_pgExists(admin_pg.Admin_Id))
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
            return View(admin_pg);
        }

        // GET: Admin_pg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Admin_Pgs == null)
            {
                return NotFound();
            }

            var admin_pg = await _context.Admin_Pgs
                .FirstOrDefaultAsync(m => m.Admin_Id == id);
            if (admin_pg == null)
            {
                return NotFound();
            }

            return View(admin_pg);
        }

        // POST: Admin_pg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Admin_Pgs == null)
            {
                return Problem("Entity set 'MyAppDataContext.Admin_Pgs'  is null.");
            }
            var admin_pg = await _context.Admin_Pgs.FindAsync(id);
            if (admin_pg != null)
            {
                _context.Admin_Pgs.Remove(admin_pg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Admin_pgExists(int id)
        {
          return _context.Admin_Pgs.Any(e => e.Admin_Id == id);
        }
    }
}
