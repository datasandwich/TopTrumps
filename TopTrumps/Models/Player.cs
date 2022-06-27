using System;
namespace TopTrumps.Models
{
	public class Player
	{
        public string Name { get; set; }
        public bool IsActivePlayer { get; set; }
        public List<Deck> PlayerHand { get; set; }
        public Player(string name, List<Deck> playerHand)
        {
            Name = name;
            IsActivePlayer = false;
            PlayerHand = playerHand;
        }
	}
}

