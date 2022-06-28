﻿namespace TopTrumps.Models;
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
    private Queue<Card>? _cards { get; set; }
    private string? _owner { get; set; }
    public string ImagePath { get; set; } = "";
    public string? getOwner() { return _owner; }
    public Queue<Card>? getCards() { return _cards; }

    public void getShuffled()
    {
        if (_cards != null)
        {
            Queue<Card> shuffled = new Queue<Card>();

            shuffled = Shuffle();
            foreach (var card in _cards)
            {
                _cards.Enqueue(shuffled.Dequeue());
                _cards.Dequeue();
            }
        }
    }
    private Queue<Card> Shuffle()
    {
        if (_cards != null) {
            List<Card> cards = new List<Card>();
            Queue<Card> shuffled = new Queue<Card>();
            foreach (var card in _cards)
            {
                cards.Add(card);
            }
            int index = 0;
            foreach (var card in _cards)
            {
                Random Jump = new Random();
                index += Jump.Next(cards.Count);
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
    public void Load(Card card)
    {
        _cards.Enqueue(card);
    }
}
