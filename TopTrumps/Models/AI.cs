using System;

namespace TopTrumps.Models
{
    public class AI : Player
    {
        public string Difficulty { get; set; }
        public Deck EntireDeck { get; set; }

        public AI(string name, Deck playerHand, string difficulty, Deck entireDeck) : base(name, playerHand)
        {
            Difficulty = difficulty;
            EntireDeck = entireDeck;
        }

        
        public int choose(Card card)
        {
            // Setting the max values for the attributes based on the deck
            int[] attr_max = maxValues();
            int[] attributeValues = new int[5];
            double[] percentages = new double[5];
            for (int i = 0; i < 5; i++)
            {
                attributeValues[i] = card.getattr(i);
                percentages[i] = card.getattr(i) / attr_max[i];
            }

            // Select the attribute to choose based on the difficulty of the AI
            int chosenIndex = 0;
            chosenIndex = Array.IndexOf(percentages,percentages.Max());

            
            return chosenIndex;
        }
        public int[] maxValues()
        {
            if (Difficulty == "easy")
            {
                var card = PlayerHand.PeekCard();
                int[] cardattr = new int[5];
                for(int i = 0; i < 5; i++)
                {
                    cardattr[i] = card.getattr(i);
                }
                return cardattr;
            }
            else
            {
                int[] maxattr = new int[5];
                foreach (var card in EntireDeck.getCards())
                {
                    for(int i = 0; i < 5; i++)
                    {
                        maxattr[i] = Math.Max(card.getattr(i), maxattr[i]);
                    }
                }
                return maxattr;
            }
        }
    }
}

