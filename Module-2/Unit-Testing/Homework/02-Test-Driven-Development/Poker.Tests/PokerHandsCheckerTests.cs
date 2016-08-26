namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerTests
    {
        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandChecker_IsValidHandShouldReturnTrueValue_WhenFiveDifferentCardsAreInTheHand()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var hand = new Hand(cards);
            var pokerHandChecker = new PokerHandsChecker();

            var actual = pokerHandChecker.IsValidHand(hand);

            Assert.IsTrue(actual);
        }

        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandChecker_IsValidHandShouldReturnTrueValue_WhenLessThanFiveDifferentCardsAreInTheHand()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            var hand = new Hand(cards);
            var pokerHandChecker = new PokerHandsChecker();

            var actual = pokerHandChecker.IsValidHand(hand);

            Assert.IsTrue(actual);
        }

        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandChecker_IsValidHandShouldReturnFalseValue_WhenMoreThanFiveDifferentCardsAreInTheHand()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var hand = new Hand(cards);
            var pokerHandChecker = new PokerHandsChecker();

            var actual = pokerHandChecker.IsValidHand(hand);

            Assert.IsFalse(actual);
        }

        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandChecker_IsValidHandShouldReturnFalseValue_WhenFiveSameCardsAreInTheHand()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
            };

            var hand = new Hand(cards);
            var pokerHandChecker = new PokerHandsChecker();

            var actual = pokerHandChecker.IsValidHand(hand);

            Assert.IsFalse(actual);
        }

        [Test]
        [Category("IsFlushTests")]
        public void PokerHandsChecker_IsFlush_ShouldReturnNoExceptions_True()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsFlush(hand);

            Assert.IsTrue(actualResult);
        }

        [Test]
        [Category("IsFlushTests")]
        public void PokerHandsCheckerIsFlush_ShouldReturnNoExceptions_False()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsFlush(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        [Category("IsFourOfAKind")]
        public void PokerHandsChecker_IsFourOfAKind_ShouldReturnNoExceptions_True()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsFourOfAKind(hand);

            Assert.IsTrue(actualResult);
        }

        [Test]
        [Category("IsFourOfAKind")]
        public void PokerHandsChecker_IsFourOfAKind_ShouldReturnFalse_WhenAddedFiveSameCardsFaceCards()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsFourOfAKind(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        [Category("IsFourOfAKind")]
        public void PokerHandsChecker_IsFourOfAKind_ShouldReturnFalse_WhenAddedFourSameCardFaceCards()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsFourOfAKind(hand);

            Assert.IsFalse(actualResult);
        }
    }
}
