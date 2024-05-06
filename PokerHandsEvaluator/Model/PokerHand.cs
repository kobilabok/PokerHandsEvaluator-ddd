using PokerHandsEvaluator.Enums;
using System;

namespace PokerHandsEvaluator.Model
{
    public class PokerHand : IComparable<PokerHand>
    {
        public IReadOnlyCollection<Card> Cards { get; }

        public PokerHand(Card card1, Card card2, Card card3, Card card4, Card card5)
        {
            Cards = new[] { card1, card2, card3, card4, card5 };
        }

        public bool HasPair() => Cards.GroupBy(card => card.Rank).Any(group => group.Count() == 2);

        public bool HasTwoPairs() => Cards.GroupBy(card => card.Rank).Count(group => group.Count() == 2) == 2;

        public bool HasThreeOfAKind() => Cards.GroupBy(card => card.Rank).Any(group => group.Count() == 3);

        public bool HasFlush() => Cards.GroupBy(card => card.Suit).Any(group => group.Count() == 5);

        public HandDealt GetHandType()
        {
            if (HasFlush()) return HandDealt.Flush;
            if (HasThreeOfAKind()) return HandDealt.ThreeOfAKind;
            if (HasTwoPairs()) return HandDealt.TwoPairs;
            if (HasPair()) return HandDealt.Pair;

            return HandDealt.HighCard;
        }

        public int CompareTo(PokerHand? other)
        {
            var typeHand1 = GetHandType();
            var typeHand2 = other.GetHandType();


            if (typeHand1 > typeHand2)
                return 1;
            else if (typeHand1 < typeHand2)
                return -1;
            else if (typeHand1 == typeHand2)
                return CompareHandsByRanks(other);

            return 0;
        }

        public int CompareHandsByRanks(PokerHand? other)
        {
            var thisSortedCards = Cards.OrderByDescending(card => card.Rank).ToList();
            var otherSortedCards = other.Cards.OrderByDescending(card => card.Rank).ToList();

            for (int i = 0; i < thisSortedCards.Count(); i++)
            {
                if (thisSortedCards.ElementAt(i).Rank > otherSortedCards.ElementAt(i).Rank)
                    return 1;
                else if (thisSortedCards.ElementAt(i).Rank < otherSortedCards.ElementAt(i).Rank)
                    return -1;
            }
            return 0;
        }
    }
}
