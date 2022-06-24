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
    public class DecksController : Controller
    {
        private readonly DeckDbContext _context;

        public DecksController(DeckDbContext context)
        {
            _context = context;
        }

        // GET: Decks
        public async Task<IActionResult> Index()
        {
              return _context.Deck != null ? 
                          View(await _context.Deck.ToListAsync()) :
                          Problem("Entity set 'DeckDbContext.Deck'  is null.");
        }

        // GET: Decks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deck == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // GET: Decks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Deck deck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deck);
        }

        // GET: Decks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deck == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }
            return View(deck);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Deck deck)
        {
            if (id != deck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckExists(deck.Id))
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
            return View(deck);
        }

        // GET: Decks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deck == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // POST: Decks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deck == null)
            {
                return Problem("Entity set 'DeckDbContext.Deck'  is null.");
            }
            var deck = await _context.Deck.FindAsync(id);
            if (deck != null)
            {
                _context.Deck.Remove(deck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckExists(int id)
        {
          return (_context.Deck?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
