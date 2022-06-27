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

        public void play()
        {
            if (!IsActivePlayer)
            {
                //Check attribute selected by player
            } else
            {
                string chosenAttribute = computeChoice();
            }
        }
        public string computeChoice()
        {
            string computation = "";
            return computation;
        }
    }
}

