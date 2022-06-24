using Microsoft.AspNetCore.Mvc;

namespace TopTrumps.Controllers
{
    public class MenuController : Controller
    {
        //game controller will be returning the data from data base 
        //here we are getting database into _db variable 
        //private readonly ApplicationDbContext _db;
        //    //we are requesting data from decks database-chage the name 
        //    public MenuController(ApplicationDbContext db)
        //{
        //        _db=db
        //}
        public IActionResult Index()
        {


            //var decksList = _db.DeckSelection.ToList();
            //var cards = _db.Cards.ToList();
            //var attributes = _db.Attributes.ToList();

            return View();
        }



    }
}
