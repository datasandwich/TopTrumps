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
        private bool end { get; set; } = false;
        
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
            nextRound();
        }
        //Initiates the next round by placing the top card of the active player's deck into play
        public void nextRound()
        {
            if (player1.PlayerHand.getCards().Count != 0)
            {
                if (player2.PlayerHand.getCards().Count != 0)
                {
                    if (player1.IsActivePlayer) { inPlay.addcard(player1.PlayerHand.getTopCard()); }
                    else { inPlay.addcard(player2.PlayerHand.getTopCard()); }
                    end = false;
                }
                else
                {
                    end = true;
                }
            }
            else
            {
                end = true;
            }
        }
        //Adds the 2nd card into play after the attribute choice is made and determines the winner
        public void choice(int chosen)
        {
            if (player1.IsActivePlayer)
            {
                inPlay.addcard(player2.PlayerHand.getTopCard());
            }
            else
            {
                inPlay.addcard(player1.PlayerHand.getTopCard());
            }
            if (inPlay.getCards().ToArray()[inPlay.getCards().Count-1].getattr(chosen) > inPlay.getCards().ToArray()[inPlay.getCards().Count - 2].getattr(chosen))
            {
                if (player1.IsActivePlayer) { addWinnings(1); }
                else { addWinnings(2); }
            }
            else
            {
                if (player2.IsActivePlayer) { addWinnings(2); }
                else { addWinnings(1); }
            }
        }
        //Sends all cards in play to the winning player
        private void addWinnings(int winner)
        {
            int Count = inPlay.getCards().Count;
            for(int i=0;i<Count;i++)
            {
                if (winner == 1) { player1.PlayerHand.addcard(inPlay.getTopCard()); }
                else { player1.PlayerHand.addcard(inPlay.getTopCard()); }
            }
            if(winner == 1) 
            { 
                player1.IsActivePlayer=true;
                player2.IsActivePlayer = false;
            }
            else 
            {
                player1.IsActivePlayer=false;
                player2.IsActivePlayer=true;
            }
        }
    }
}


