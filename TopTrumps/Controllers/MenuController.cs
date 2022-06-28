using Microsoft.AspNetCore.Mvc;
using TopTrumps.Data;
using TopTrumps.Models;

namespace TopTrumps.Controllers
{
    public class MenuController : Controller
    {

        //here we are getting database into _db variable 
        private readonly DeckDbContext _db;
        int deck;
        string player;

        //populate local variable_db with db object fron services
        public MenuController(DeckDbContext db)
        {
            _db = db;
        }


        //var decksList = _db.DeckSelection.ToList();
        //var cards = _db.Cards.ToList();
        //var attributes = _db.Attributes.ToList();
        public IActionResult Index()
        {
            IEnumerable<Deck> objDeckList = _db.Deck;

            return View(objDeckList);

        }

        public IActionResult checkDeck(int button)
        {

            deck = button;
  
            return RedirectToAction("Index");
        }
        public IActionResult chooseMode(string button)

        {

            player = button;

            return RedirectToAction("Index");
        }

        public IActionResult startGame()

        {
            if(deck!=null && player != null)
            {
                return RedirectToAction("Index", "Game");
            }

            return View("Index");
        }
    }

}
