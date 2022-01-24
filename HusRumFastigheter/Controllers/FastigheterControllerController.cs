using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HusRumFastigheter.Models;

namespace HusRumFastigheter.Controllers
{
    public class FastigheterControllerController : Controller
    {
        private readonly Context _context;

        public FastigheterControllerController(Context context)
        {
            _context = context;
        }

        // GET: FastigheterController
        public async Task<IActionResult> Index()
        {
            var context = _context.fastigheterControllers.Include(f => f.Door).Include(f => f.Event).Include(f => f.Location).Include(f => f.Tenant);
            return View(await context.ToListAsync());
        }

        // GET: FastigheterController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fastigheterController = await _context.fastigheterControllers
                .Include(f => f.Door)
                .Include(f => f.Event)
                .Include(f => f.Location)
                .Include(f => f.Tenant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fastigheterController == null)
            {
                return NotFound();
            }

            return View(fastigheterController);
        }

        // GET: FastigheterController/Create
        public IActionResult Create()
        {
            ViewData["DoorId"] = new SelectList(_context.doors, "ID", "DoorCode");
            ViewData["EventId"] = new SelectList(_context.events, "id", "EventCode");
            ViewData["LocationId"] = new SelectList(_context.locations, "ID", "Type");
            ViewData["TenantId"] = new SelectList(_context.tenants, "Id", "FullName");
            return View();
        }

        // POST: FastigheterController/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,DoorId,EventId,PersonTag,TenantId,LocationId,Description")] FastigheterController fastigheterController)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fastigheterController);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoorId"] = new SelectList(_context.doors, "ID", "DoorCode", fastigheterController.DoorId);
            ViewData["EventId"] = new SelectList(_context.events, "id", "EventCode", fastigheterController.EventId);
            ViewData["LocationId"] = new SelectList(_context.locations, "ID", "Type", fastigheterController.LocationId);
            ViewData["TenantId"] = new SelectList(_context.tenants, "Id", "FullName", fastigheterController.TenantId);
            return View(fastigheterController);
        }

        // GET: FastigheterController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fastigheterController = await _context.fastigheterControllers.FindAsync(id);
            if (fastigheterController == null)
            {
                return NotFound();
            }
            ViewData["DoorId"] = new SelectList(_context.doors, "ID", "DoorCode", fastigheterController.DoorId);
            ViewData["EventId"] = new SelectList(_context.events, "id", "EventCode", fastigheterController.EventId);
            ViewData["LocationId"] = new SelectList(_context.locations, "ID", "Type", fastigheterController.LocationId);
            ViewData["TenantId"] = new SelectList(_context.tenants, "Id", "FullName", fastigheterController.TenantId);
            return View(fastigheterController);
        }

        // POST: FastigheterController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,DoorId,EventId,PersonTag,TenantId,LocationId,Description")] FastigheterController fastigheterController)
        {
            if (id != fastigheterController.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fastigheterController);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FastigheterControllerExists(fastigheterController.Id))
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
            ViewData["DoorId"] = new SelectList(_context.doors, "ID", "DoorCode", fastigheterController.DoorId);
            ViewData["EventId"] = new SelectList(_context.events, "id", "EventCode", fastigheterController.EventId);
            ViewData["LocationId"] = new SelectList(_context.locations, "ID", "Type", fastigheterController.LocationId);
            ViewData["TenantId"] = new SelectList(_context.tenants, "Id", "FullName", fastigheterController.TenantId);
            return View(fastigheterController);
        }

        // GET: FastigheterController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fastigheterController = await _context.fastigheterControllers
                .Include(f => f.Door)
                .Include(f => f.Event)
                .Include(f => f.Location)
                .Include(f => f.Tenant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fastigheterController == null)
            {
                return NotFound();
            }

            return View(fastigheterController);
        }

        // POST: FastigheterController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fastigheterController = await _context.fastigheterControllers.FindAsync(id);
            _context.fastigheterControllers.Remove(fastigheterController);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FastigheterControllerExists(int id)
        {
            return _context.fastigheterControllers.Any(e => e.Id == id);
        }
    }
}
