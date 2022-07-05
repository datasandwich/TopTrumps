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
                await Populate(allCards);
                //shuffles
                allCards.getShuffled();
                //distributes the cards evenly between the 2 players
                if (mode == "Local")
                {
                    player2 = new Player("", new(0, "", ""));
                }
                else if (mode == "EasyAI")
                {
                    player2 = new AI("TrumpNovice", new(0, "", ""), false);
                }
                else
                {
                    player2 = new AI("TrumpMaster", new(0, "", ""), true);
                }
                if (allCards.Id != 0)
                {
                    int totcards = allCards.getCards().Count / 2;
                    for (int i = 0; i < totcards; i++)
                    {
                        player1.PlayerHand.addcard(allCards.getTopCard());
                        player2.PlayerHand.addcard(allCards.getTopCard());
                    }
                }
                //sets the attribute names
                await getAttributes();
                if(mode == "Local")
                    //Coin toss to see who goes first
                {
                    Random coinToss = new();
                    int result = coinToss.Next(2);
                    switch (result)
                    {
                        case 0: player1.IsActivePlayer = true; break;
                        case 1: player2.IsActivePlayer = true; break;
                    }
                }
                else
                //Real player goes first
                {
                    player1.IsActivePlayer = true;
                }
                //START The GAME
                      
                return View("Index");
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

     

    }
}
