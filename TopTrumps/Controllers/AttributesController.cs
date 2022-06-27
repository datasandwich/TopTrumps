using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopTrumps.Data;
using TopTrumps.Models;

namespace TopTrumps.Controllers
{
    public class AttributesController : Controller
    {
        private readonly DeckDbContext _context;

        public AttributesController(DeckDbContext context)
        {
            _context = context;
        }

        // GET: Attributes
        public async Task<IActionResult> Index()
        {
              return _context.Attribute != null ? 
                          View(await _context.Attribute.ToListAsync()) :
                          Problem("Entity set 'DeckDbContext.Attribute'  is null.");
        }

        // GET: Attributes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attribute == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attribute
                .FirstOrDefaultAsync(m => m.ID == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // GET: Attributes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Deckid,Attr1,Attr2,Attr3,Attr4,Attr5")] Attributes attribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attribute);
        }

        // GET: Attributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attribute == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attribute.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }
            return View(attribute);
        }

        // POST: Attributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Deckid,Attr1,Attr2,Attr3,Attr4,Attr5")] Attributes attribute)
        {
            if (id != attribute.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeExists(attribute.ID))
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
            return View(attribute);
        }

        // GET: Attributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attribute == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attribute
                .FirstOrDefaultAsync(m => m.ID == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // POST: Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attribute == null)
            {
                return Problem("Entity set 'DeckDbContext.Attribute'  is null.");
            }
            var attribute = await _context.Attribute.FindAsync(id);
            if (attribute != null)
            {
                _context.Attribute.Remove(attribute);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeExists(int id)
        {
          return (_context.Attribute?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
