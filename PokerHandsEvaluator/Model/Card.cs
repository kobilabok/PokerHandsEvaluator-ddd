using PokerHandsEvaluator.Enums;
using System;

namespace PokerHandsEvaluator.Model
{
    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
