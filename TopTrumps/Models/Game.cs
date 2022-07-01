using System;
namespace TopTrumps.Models
{
    public class Game
    {
        public Attributes attributes { get; set; }
        public Player player1 { get; set; } = new("", new(0, "", ""));
        public Player player2 { get; set; }
        public Deck? inPlay { get; set; }
        public string mode { get; set; }

        public Game(Attributes attributes, Player player1, Player player2, Deck? inPlay, string mode)
        {
            this.attributes = attributes;
            this.player1 = player1;
            this.player2 = player2;
            this.inPlay = inPlay;
            this.mode = mode;
        }

        public void startGame()
        {
            //shuffles
            inPlay.getShuffled();
            //distributes the cards evenly between the 2 players
            if (mode == "Local")
            {
                player2 = new Player("", new(0, "", ""));
            }
            else if (mode == "EasyAI")
            {
                player2 = new AI("TrumpNovice", new(0, "", ""), "easy",inPlay);
            }
            else
            {
                player2 = new AI("TrumpMaster", new(0, "", ""), "hard",inPlay);
            }
            if (inPlay.Id != 0)
            {
                int totcards = inPlay.getCards().Count / 2;
                for (int i = 0; i < totcards; i++)
                {
                    player1.PlayerHand.addcard(inPlay.getTopCard());
                    player2.PlayerHand.addcard(inPlay.getTopCard());
                }
            }

            if (mode == "Local")
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
            
            /*
             * 
             * Pseudocode
             * 
            Deck activeDeck = Deck.Load();
            Player playerOne = new Player("Roy", playerOneHand);
            Player playerTwo = new AI("AI", playerTwoHand, difficulty);

            playerOne.IsActivePlayer = true;

            bool gameOver = false;

            while (!gameOver){

                * Draw a card from top of deck.
                Card playerOneTopCard = playerOne.dequeue(playerOneHand);
                Card playerTwoTopCard = playerTwo.dequeue(playerTwoHand);

                * Decide which player is choosing the attribute for this round.
                if (playerOne.IsActivePlayer){
                    chosenAttribute = playerOne.input();
                } else {chosenAttribute = playerTwo.choose();}

                * Compare attribute values to decide round winner.
                if (playerOneTopCard.chosenAttribute > playerTwoTopCard.chosenAttribute){
                    playerOneHand.Add(playerTwoTopCard);
                    playerOne.isActivePlayer = true;
                    playerTwo.isActivePlayer = false;
                } else {
                    playerTwoHand.Add(playerOneTopCard);
                    playerTwo.isActivePlayer = true;
                    playerOne.isActivePlayer = false;
                }


                * Decide Winner
                if (playerOne.playerOneHand.Count == 0){
                    Console.WriteLine("Player Two Wins!");
                    gameOver = true;
                } else {
                    Console.WriteLine("Player One Wins!"):
                    gameOver = true;
                }
            }

            */
        }
        public void nextRound() { }
        public void Endgame() { }
    }
}


