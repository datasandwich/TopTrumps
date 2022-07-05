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
        public Deck allCards = new(0,"FullDeck","");
        public Attributes attributes;
        public Player player1 = new("",new(0,"",""));
        public Player player2;
        public Deck? inPlay;
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
                //sets the attribute names
                await getAttributes();
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
                      
                return RedirectToAction("Index", "Game");
            }

            return RedirectToAction("Index","Game");
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
                        allCards = adeck;
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
                attributes = a;
            }
        }

     

    }
}
