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


            //int deck;
            //string player;
            //string btState = "active";
        

       

        //int deck;
        //string player;
        //string btState = "active";

        //var decksList = _db.DeckSelection.ToList();
        //var cards = _db.Cards.ToList();
        //var attributes = _db.Attributes.ToList();
        //public IActionResult Index()
        //{
        //    IEnumerable<Deck> objDeckList = _db.Deck;

        //    return View(objDeckList);

        //}
        public async Task<IActionResult> Index()
        {
            await _db.SaveChangesAsync();
            return _db.Deck != null ?
                          View(await _db.Deck.ToListAsync()) :
                          Problem("Entity set 'DeckDbContext.Deck'  is null.");
        }

        //public IActionResult checkDeck(string button)
        //{

        //    deck = Int32.Parse(button);

        //    return View("Index", btState);
        //}
        //public IActionResult chooseMode(string button)

        //{

        //    player = button;

        //    return RedirectToAction("Index");
        //}

        //public IActionResult ProcessForm(string deckId, string playerId)

        //{

        //    deck = Int32.Parse(deckId);
        //    player = playerId;

        //    if (deck!=null && player != null)
        //    {
        //        Choice choice = new Choice(deck,player);
        //        return RedirectToAction("Index", "Game");
        //    }

        //    return View("Index");
        //}
    }

}
