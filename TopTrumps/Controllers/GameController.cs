using Microsoft.AspNetCore.Mvc;
using TopTrumps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TopTrumps.Controllers
{
    public class GameController : Controller
    {
        private readonly DeckDbContext _context;

        public GameController(DeckDbContext context)
        {
            _context = context;
        }


        public int deck;
        public string mode;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetDeckIdAndMode(string deckIdButton, string modeChoice)

        {

            deck = Int32.Parse(deckIdButton);
            mode = modeChoice;

            if (deck != null && mode != null)
            {
                

                //START The GAME
                      
                return View();
            }

            return View("Index","Menu");
        }



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

    }
}
