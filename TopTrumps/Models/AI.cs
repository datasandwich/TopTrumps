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

        
        public string choose(Card card, Attributes attributes)
        {

            switch (card.Deckid)
            {
                case 0:
                    int[] attr_max = { 0,0,0,0,0};
                    break;
                case 1:
                    int[] attr_max = { 40, 100, 200, 15, 50 };
                    break;
                case 2:
                    int[] attr_max = { 0, 0, 0, 0, 0 };
                    break;
            }
            string choice = "";

            float[] percentages = { card.Attr1 / attr_max[0], card.Attr2 / attr_max[1], card.Attr3 / attr_max[2], card.Attr4 / attr_max[3], card.Attr5 / attr_max[3] };

            var maxIndex = percentages.IndexOf(percentages.Max());

            string[] cardAttributes = { attributes.Attr1, attributes.Attr2, attributes.Attr3, attributes.Attr4, attributes.Attr5 };

            choice = cardAttributes[maxIndex];

            return choice;
        }
    }
}

