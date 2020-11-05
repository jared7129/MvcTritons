using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTriton.Data;
using MvcTriton.Models;

namespace MvcTriton.Controllers
{
    public class WaybillController : Controller
    {
        private readonly MvcTritonContext _context;

        public WaybillController(MvcTritonContext context)
        {
            _context = context;
        }

        // GET: Waybill
        public async Task<IActionResult> Index()
        {
            return View(await _context.Waybill.ToListAsync());
        }

        // GET: Waybill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waybill == null)
            {
                return NotFound();
            }

            return View(waybill);
        }

        // GET: Waybill/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Waybill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,CustomerAddress,CustomerNumber,TotalWeight,NoParcels,TotalValue")] Waybill waybill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waybill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waybill);
        }

        // GET: Waybill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybill.FindAsync(id);
            if (waybill == null)
            {
                return NotFound();
            }
            return View(waybill);
        }

        // POST: Waybill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,CustomerAddress,CustomerNumber,TotalWeight,NoParcels,TotalValue")] Waybill waybill)
        {
            if (id != waybill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waybill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaybillExists(waybill.Id))
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
            return View(waybill);
        }

        // GET: Waybill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waybill == null)
            {
                return NotFound();
            }

            return View(waybill);
        }

        // POST: Waybill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waybill = await _context.Waybill.FindAsync(id);
            _context.Waybill.Remove(waybill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaybillExists(int id)
        {
            return _context.Waybill.Any(e => e.Id == id);
        }
    }
}
