namespace TopTrumps.Models;
using System.Linq;

public class Deck
{
    public Deck(int id, string name, string imagePath)
    {  
        Id = id;
        Name = name;
        ImagePath = imagePath;
    }
    public int Id { get; set; }
    public string Name { get; set; } = "";
    private Queue<Card>? _cards { get; set; } = new Queue<Card>();
    private string? _owner { get; set; }
    public string ImagePath { get; set; } = "";
    public string? getOwner() { return _owner; }
    public Queue<Card>? getCards() { return _cards; }

    //I need deck attributes her??? 

    public void getShuffled()
    {
        if (_cards != null)
        {
            _cards = Shuffle();
        }
    }
    private Queue<Card> Shuffle()
    {
        if (_cards != null) {
            List<Card> cards = new();
            Queue<Card> shuffled = new();
            foreach (var card in _cards)
            {
                cards.Add(card);
            }
            int index = 0;
            foreach (var card in _cards)
            {
                Random Jump = new Random();
                index = Jump.Next(cards.Count);
                shuffled.Enqueue(cards[index]);
                cards.RemoveAt(index);
            }
            return shuffled;
        }
        return new Queue<Card>();
    }
    public void addcard(Card newcard)
    {
        _cards.Enqueue(newcard);
    }
    public Card getTopCard()
    {
        return _cards.Dequeue();
    }
}
