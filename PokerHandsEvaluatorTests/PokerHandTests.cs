using FluentAssertions;
using PokerHandsEvaluator;
using PokerHandsEvaluator.Enums;
using PokerHandsEvaluator.Model;
using Xunit;

namespace PokerHandsEvaluatorTests
{
    public class PokerHandTests
    {
        [Fact]
        public void HandWith_HigherCard_ShouldWin()
        {
            // Arrange
            var hand1 = new PokerHand(
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Spades, Rank.Three),
                new Card(Suit.Hearts, Rank.Ace),
                new Card(Suit.Clubs, Rank.King),
                new Card(Suit.Clubs, Rank.Four));

            var hand2 = new PokerHand(
                new Card(Suit.Hearts, Rank.Jack),
                new Card(Suit.Diamonds, Rank.King),
                new Card(Suit.Hearts, Rank.Two),
                new Card(Suit.Spades, Rank.Three),
                new Card(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.HighCard);
        }

        [Fact]
        public void HandWith_Pair_ShouldWin()
        {
            // Arrange
            var hand1 = new PokerHand(
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Spades, Rank.Two),
                new Card(Suit.Hearts, Rank.Ace),
                new Card(Suit.Clubs, Rank.Jack),
                new Card(Suit.Clubs, Rank.Four));

            var hand2 = new PokerHand(
                new Card(Suit.Hearts, Rank.Four),
                new Card(Suit.Diamonds, Rank.Jack),
                new Card(Suit.Hearts, Rank.Two),
                new Card(Suit.Spades, Rank.Three),
                new Card(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.Pair);
        }

        [Fact]
        public void HandWith_HigherPair_ShouldWin()
        {
            // Arrange
            var hand1 = new PokerHand(
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Spades, Rank.Two),
                new Card(Suit.Hearts, Rank.Ace),
                new Card(Suit.Clubs, Rank.Jack),
                new Card(Suit.Clubs, Rank.Four));

            var hand2 = new PokerHand(
                new Card(Suit.Hearts, Rank.Four),
                new Card(Suit.Diamonds, Rank.Four),
                new Card(Suit.Hearts, Rank.Two),
                new Card(Suit.Spades, Rank.Three),
                new Card(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.Pair);
        }

        [Fact]
        public void BothHandsWith_SamePair_HandWithHighestCardShouldWin()
        {
            // Arrange
            var hand1 = new PokerHand(
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Spades, Rank.Two),
                new Card(Suit.Hearts, Rank.Ace),
                new Card(Suit.Clubs, Rank.Jack),
                new Card(Suit.Clubs, Rank.Four));

            var hand2 = new PokerHand(
                new Card(Suit.Hearts, Rank.Two),
                new Card(Suit.Diamonds, Rank.Two),
                new Card(Suit.Hearts, Rank.Ace),
                new Card(Suit.Spades, Rank.Jack),
                new Card(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand2.Should().BeGreaterThan(hand1);
            hand2.GetHandType().Should().Be(HandDealt.Pair);
        }

        [Fact]
        public void HandWith_ThreeOfAKind_ShouldWin()
        {
            // Arrange
            var hand1 = new PokerHand(
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Spades, Rank.Three),
                new Card(Suit.Hearts, Rank.Ace),
                new Card(Suit.Clubs, Rank.Jack),
                new Card(Suit.Clubs, Rank.Four));

            var hand2 = new PokerHand(
                new Card(Suit.Hearts, Rank.Two),
                new Card(Suit.Diamonds, Rank.Two),
                new Card(Suit.Hearts, Rank.Three),
                new Card(Suit.Spades, Rank.Three),
                new Card(Suit.Spades, Rank.Three));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand2.Should().BeGreaterThan(hand1);
            hand2.GetHandType().Should().Be(HandDealt.ThreeOfAKind);
        }

        [Fact]
        public void HandsWith_Flush_ShouldWin()
        {
            // Arrange
            var hand1 = new PokerHand(
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Jack),
                new Card(Suit.Clubs, Rank.Four));

            var hand2 = new PokerHand(
                new Card(Suit.Hearts, Rank.Two),
                new Card(Suit.Diamonds, Rank.Two),
                new Card(Suit.Hearts, Rank.Three),
                new Card(Suit.Spades, Rank.Three),
                new Card(Suit.Spades, Rank.Three));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.Flush);
        }
    }
}