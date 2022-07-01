using Microsoft.AspNetCore.Mvc;
using TopTrumps.Data;
using Microsoft.EntityFrameworkCore;
using TopTrumps.Models;

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
        public Game game = new(new(0,0,"","","","",""),new("",new(0,"","")),new("",new(0,"","")),null,"");
        public Deck allCards;
        public Attributes attributes;
        public IActionResult Index()
        {
            //Player1 and Player2 hands are face down
            //player1.getTopCard is revealed and put into inPlay
            //View updated (inPlay.getCards(0))
            //player1 selects category
            //player2.getTopCard is revealed and put into inPlay
            //categories compared, a player wins
            //winningplayer.addCard(each inPlay)
            //inPlay = null
            return View();
        }

        public async Task<IActionResult> GetDeckIdAndMode(string deckIdButton, string modeChoice)

        {

            deck = Int32.Parse(deckIdButton);
            mode = modeChoice;

            if (deck != null && mode != null)
            {
                //gets the cards for the chosen deck
                await setDeck();
                await Populate(game.inPlay);
                //sets the attribute names
                await getAttributes();
                game.startGame();
                
                //START The GAME
                      
                return View("Index",game);
            }

            return View("Index","Game");
        }
        public async Task setDeck()
        {
            var decks = await _context.Deck.FromSqlRaw($"SELECT * FROM Deck WHERE id = {deck}").ToListAsync();
            do
            {
                if (decks != null)
                {
                    foreach (var adeck in decks)
                    {
                        game.inPlay = adeck;
                    }
                }
            }while (decks == null);
        }
        //Gets a list of cards in adeck(id=deckid)
        public async Task Populate(Deck adeck)
        {
            var cards = await _context.Card.FromSqlRaw($"SELECT * FROM card WHERE deckid = {adeck.Id}").ToListAsync();
            do
            {
                if (cards != null)
                {
                    foreach (Card card in cards)
                    {
                        adeck.addcard(card);
                    }
                }
            }while (cards == null);
        }
        public async Task getAttributes()
        {
            var attribute = await _context.Attribute.FromSqlRaw($"SELECT * FROM Attribute WHERE deckid = {deck}").ToListAsync();
            foreach(Attributes a in attribute)
            {
                game.attributes = a;
            }
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
