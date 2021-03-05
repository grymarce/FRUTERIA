using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FRUTERIA.Data;
using FRUTERIA.Models;
using Microsoft.AspNetCore.Authorization;

namespace FRUTERIA.Views.FRUTERIA_MAR
{
    public class FRUTERIA_MARController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FRUTERIA_MARController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FRUTERIA_MAR
        public async Task<IActionResult> Index()
        {
            return View(await _context.FRUTERIA_MAR.ToListAsync());
        }

        // GET: FRUTERIA_MAR/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fRUTERIA_MAR = await _context.FRUTERIA_MAR
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fRUTERIA_MAR == null)
            {
                return NotFound();
            }

            return View(fRUTERIA_MAR);
        }

        // GET: FRUTERIA_MAR/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FRUTERIA_MAR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] Models.FRUTERIA_MAR fRUTERIA_MAR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fRUTERIA_MAR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fRUTERIA_MAR);
        }

        // GET: FRUTERIA_MAR/Edit/5
        [Authorize]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fRUTERIA_MAR = await _context.FRUTERIA_MAR.FindAsync(id);
            if (fRUTERIA_MAR == null)
            {
                return NotFound();
            }
            return View(fRUTERIA_MAR);
        }

        // POST: FRUTERIA_MAR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] Models.FRUTERIA_MAR fRUTERIA_MAR)
        {
            if (id != fRUTERIA_MAR.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fRUTERIA_MAR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FRUTERIA_MARExists(fRUTERIA_MAR.Id))
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
            return View(fRUTERIA_MAR);
        }

        // GET: FRUTERIA_MAR/Delete/5
        [Authorize]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fRUTERIA_MAR = await _context.FRUTERIA_MAR
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fRUTERIA_MAR == null)
            {
                return NotFound();
            }

            return View(fRUTERIA_MAR);
        }

        // POST: FRUTERIA_MAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fRUTERIA_MAR = await _context.FRUTERIA_MAR.FindAsync(id);
            _context.FRUTERIA_MAR.Remove(fRUTERIA_MAR);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FRUTERIA_MARExists(int id)
        {
            return _context.FRUTERIA_MAR.Any(e => e.Id == id);
        }
    }
}
