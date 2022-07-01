using System;

namespace TopTrumps.Models
{
    public class AI : Player
    {
        public string Difficulty { get; set; }

        public AI(string name, Deck playerHand, string difficulty) : base(name, playerHand)
        {
            Difficulty = difficulty;
        }

        
        public string choose(Card card, Attributes attributes)
        {
            string choice = "";
            /*
            // Setting the max values for the attributes based on the deck
            int[] attr_max = new int[5];
            switch (card.Deckid)
            {
                case 0:
                    attr_max[0] = 0;
                    attr_max[1] = 0;
                    attr_max[2] = 0;
                    attr_max[3] = 0;
                    attr_max[4] = 0;
                    break;
                case 1:
                    attr_max[0] = 0;
                    attr_max[1] = 0;
                    attr_max[2] = 0;
                    attr_max[3] = 0;
                    attr_max[4] = 0;
                    break;
                case 2:
                    attr_max[0] = 40;
                    attr_max[1] = 110;
                    attr_max[2] = 210;
                    attr_max[3] = 20;
                    attr_max[4] = 50;
                    break;
            }

            
            int[] attributeValues = { card.Attr1, card.Attr2, card.Attr3, card.Attr4, card.Attr5 };
            float[] percentages = { card.Attr1 / attr_max[0], card.Attr2 / attr_max[1], card.Attr3 / attr_max[2], card.Attr4 / attr_max[3], card.Attr5 / attr_max[3] };

            // Select the attribute to choose based on the difficulty of the AI
            int chosenIndex;
            if (Difficulty == "easy")
            {
                chosenIndex = attributeValues.IndexOf(attributeValues.Max());
            } else
            {
                chosenIndex = percentages.IndexOf(percentages.Max());
            }

            string[] cardAttributes = { attributes.Attr1, attributes.Attr2, attributes.Attr3, attributes.Attr4, attributes.Attr5 };
            choice = cardAttributes[chosenIndex];

            */
            return choice;
        }
    }
}

