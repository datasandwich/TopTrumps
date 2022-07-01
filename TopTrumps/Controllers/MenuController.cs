using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopTrumps.Data;
using TopTrumps.Models;

namespace TopTrumps.Controllers
{
    public class MenuController : Controller
    {

        //here we are getting database into _db variable 
        private readonly DeckDbContext _db;
     

        //populate local variable_db with db object fron services
        public MenuController(DeckDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            await _db.SaveChangesAsync();
            return _db.Deck != null ?
                          View(await _db.Deck.ToListAsync()) :
                          Problem("Entity set 'DeckDbContext.Deck'  is null.");
        }
    }
}
