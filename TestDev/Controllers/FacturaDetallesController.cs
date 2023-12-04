using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestDev.Models;
using TestDev.Models.ViewModels;

namespace TestDev.Controllers
{
    public class FacturaDetallesController : Controller
    {
        private readonly FacturadorDBContext _DBcontext;

        public FacturaDetallesController(FacturadorDBContext context)
        {
            _DBcontext = context;
        }

        // GET: FacturaDetalles
        public async Task<IActionResult> Index()
        {
            var facturadorDBContext = _DBcontext.FacturaDetalles.Include(f => f.Art).Include(f => f.Fact);
            return View(await facturadorDBContext.ToListAsync());
        }

        // GET: FacturaDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _DBcontext.FacturaDetalles == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _DBcontext.FacturaDetalles
                .Include(f => f.Art)// sera por esto que rompia antes?
                .Include(f => f.Fact)
                .FirstOrDefaultAsync(m => m.FcDtlId == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Create
        public IActionResult Create(int fcID)
        {
            FacturaDetalleVM facturaDetalleVM = new FacturaDetalleVM()
            {
                oDetalle = new FacturaDetalle()
            };
            int CabeceraId = fcID;

            if (fcID != 0)
            {
                facturaDetalleVM.oDetalle = _DBcontext.FacturaDetalles.Find(fcID);
            }


            ViewData["ArtId"] = new SelectList(_DBcontext.Articulos, "ArtId", "ArtId");
            //ViewBag.CabeceraId = fcID;
            //ViewData["FactId"] = new SelectList(_DBcontext.FacturaCabeceras, "FcId", "FcId");
            return View(facturaDetalleVM);
        }

        // POST: FacturaDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("FactId,FcDtlId,FechaAlta,ArtId,Cant,Precio,Monto")]*/ FacturaDetalle facturaDetalle)
        {



            if (facturaDetalle.FcDtlId == 0)
            {
                _DBcontext.FacturaDetalles.Add(facturaDetalle);
            }
            
            
            
            _DBcontext.SaveChanges();
            //if (ModelState.IsValid)
            //{
            //    _context.Add(facturaDetalle);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //else
            //{
            //    foreach (var item in ModelState.Keys)
            //    {
            //        var keyError = ModelState[item].Errors;
            //        foreach (var error in keyError)
            //        {
            //            Console.WriteLine($"- {error.ErrorMessage}");
            //        }
            //    } 

            //}

            //ViewData["ArtId"] = new SelectList(_context.Articulos, "ArtId", "ArtId", facturaDetalle.ArtId);
            //ViewData["FactId"] = new SelectList(_context.FacturaCabeceras, "FcId", "FcId", facturaDetalle.FactId);
            //return View(facturaDetalle);
            return RedirectToAction("Index");
        }

        // GET: FacturaDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            FacturaDetalleVM oDetalleVM = new FacturaDetalleVM()
            {
                oDetalle = new FacturaDetalle()
            };
            if (id != 0)
            {
                oDetalleVM.oDetalle = _DBcontext.FacturaDetalles.Find(id);
            }
            ViewData["ArtId"] = new SelectList(_DBcontext.Articulos, "ArtId", "ArtId", oDetalleVM.oDetalle.ArtId);
            return View(oDetalleVM);
            //if (id == null || _DBcontext.FacturaDetalles == null)
            //{
            //    return NotFound();
            //}

            //var facturaDetalle = await _DBcontext.FacturaDetalles.FindAsync(id);
            //if (facturaDetalle == null)
            //{
            //    return NotFound();
            //}
            
            //ViewData["FactId"] = new SelectList(_DBcontext.FacturaCabeceras, "FcId", "FcId", facturaDetalle.FactId);
            //return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(/*int id ,*/FacturaDetalleVM oDetalleVM)
        {
            
            FacturaDetalle facturaDetalle = await _DBcontext.FacturaDetalles.FindAsync(oDetalleVM.oDetalle.FcDtlId);
            if (facturaDetalle == null)
            {
                return NotFound();
            }
            _DBcontext.Entry(facturaDetalle).CurrentValues.SetValues(oDetalleVM.oDetalle);
            await _DBcontext.SaveChangesAsync();
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        
            //        await _DBcontext.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!FacturaDetalleExists(facturaDetalle.FcDtlId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["ArtId"] = new SelectList(_DBcontext.Articulos, "ArtId", "ArtId", oDetalleVM.oDetalle.ArtId);
            ViewData["FactId"] = new SelectList(_DBcontext.FacturaCabeceras, "FcId", "FcId", oDetalleVM.oDetalle.FactId);
            //return View(facturaDetalle);
            return RedirectToAction(nameof(Index));
        }

        // GET: FacturaDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _DBcontext.FacturaDetalles == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _DBcontext.FacturaDetalles
                .Include(f => f.Art)
                .Include(f => f.Fact)
                .FirstOrDefaultAsync(m => m.FcDtlId == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_DBcontext.FacturaDetalles == null)
            {
                return Problem("Entity set 'FacturadorDBContext.FacturaDetalles'  is null.");
            }
            var facturaDetalle = await _DBcontext.FacturaDetalles.FindAsync(id);
            if (facturaDetalle != null)
            {
                _DBcontext.FacturaDetalles.Remove(facturaDetalle);
            }
            
            await _DBcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaDetalleExists(int id)
        {
          return (_DBcontext.FacturaDetalles?.Any(e => e.FcDtlId == id)).GetValueOrDefault();
        }
    }
}
