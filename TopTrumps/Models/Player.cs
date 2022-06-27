using System;
namespace TopTrumps.Models
{
	public class Player
	{
        public string Name { get; set; }
        public bool IsActivePlayer { get; set; }
        public Deck PlayerHand { get; set; }
        public Player(string name, Deck playerHand)
        {
            Name = name;
            IsActivePlayer = false;
            PlayerHand = playerHand;
        }
	}
}

