using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OceanicAirlinesWebApp.Algorithms;
using OceanicAirlinesWebApp.Data;
using OceanicAirlinesWebApp.Models;

namespace OceanicAirlinesWebApp.Controllers
{
    public class ParcelsController : Controller
    {
        private readonly OceanicAirlinesWebAppContext _context;

        public ParcelsController(OceanicAirlinesWebAppContext context)
        {
            _context = context;
        }

        // GET: Parcels
        public async Task<IActionResult> Index()
        {
            return _context.Parcel != null ?
                        View(await _context.Parcel.ToListAsync()) :
                        Problem("Entity set 'OceanicAirlinesWebAppContext.Parcel'  is null.");
        }

        // GET: Parcels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parcel == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // GET: Parcels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parcels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,From,To,Weight,Size,Category")] Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                Graph graph = new Graph();
                var result = graph.Dijkstra(
                    graph.Nodes.Find(node => node.Name.ToLower() == parcel.From.ToLower()).Id,
                    graph.Nodes.Find(node => node.Name.ToLower() == parcel.To.ToLower()).Id, e => e.Time);
                var newParcel = new Parcel()
                {
                    Category = parcel.Category,
                    From = parcel.From,
                    To = parcel.To,
                    Weight = parcel.Weight,
                    Height = parcel.Height,
                    Width = parcel.Width,
                    Length = parcel.Length,
                    Name = parcel.Name,
                    Email = parcel.Email,
                };
                result.CalculatePriceAndTime(parcel);
                parcel.Price = result.TotalPrice;
                parcel.Size = parcel.CalculatedSize;
                parcel.Time = result.TotalTime;
                _context.Parcel.Add(parcel);
                await _context.SaveChangesAsync();
                Invoice invoice = new Invoice();
                invoice.sendEmail(parcel.Id.ToString(), parcel.Name, parcel.Email, parcel.Price.ToString(), parcel.Time.ToString(), parcel.From, parcel.To);

                return RedirectToAction("Details", "Parcels", new { id = parcel.Id });
            }
            return View(parcel);
        }

        // GET: Parcels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parcel == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            return View(parcel);
        }

        // POST: Parcels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,From,To,Weight,Size")] Parcel parcel)
        {
            if (id != parcel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcelExists(parcel.Id))
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
            return View(parcel);
        }

        // GET: Parcels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parcel == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // POST: Parcels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parcel == null)
            {
                return Problem("Entity set 'OceanicAirlinesWebAppContext.Parcel'  is null.");
            }
            var parcel = await _context.Parcel.FindAsync(id);
            if (parcel != null)
            {
                _context.Parcel.Remove(parcel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcelExists(int id)
        {
            return (_context.Parcel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
