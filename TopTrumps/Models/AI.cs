using System;

namespace TopTrumps.Models
{
    public class AI : Player
    {
        public bool Difficulty { get; set; }

        public AI(string name, Deck playerHand, bool difficulty) : base(name, playerHand)
        {
            Difficulty = difficulty;
        }

        
        public string choose(Card card)
        {
            string choice = "";
            return choice;
        }
    }
}

