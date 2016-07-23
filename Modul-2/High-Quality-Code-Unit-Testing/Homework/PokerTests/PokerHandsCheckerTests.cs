namespace PokerTests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class PokerHandsCheckerTests
    {
        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandsCheckerIsValidHand_ShouldReturnNoExceptions_True()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsValidHand(hand);

            Assert.IsTrue(actualResult);
        }

        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandsCheckerIsValidHand_ShouldReturnNoExceptions_False()
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
            var actualResult = pokerHand.IsValidHand(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandsCheckerIsValidHand_ShouldReturnTrueIfCardsAreLessThanValidAmountOfCards()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsValidHand(hand);

            Assert.IsTrue(actualResult);
        }

        [Test]
        [Category("IsValidHandTests")]
        public void PokerHandsCheckerIsValidHand_ShouldReturnFalseIfCardsAreLessThanValidAmountOfCards()
        {
            var pokerHand = new PokerHandsChecker();
            var listOfCard = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
            };

            var hand = new Hand(listOfCard);
            var actualResult = pokerHand.IsValidHand(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        [Category("IsFlushTests")]
        public void PokerHandsCheckerIsFlush_ShouldReturnNoExceptions_True()
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
        public void PokerHandsCheckerIsFourOfAKind_ShouldReturnNoExceptions_True()
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
        public void PokerHandsCheckerIsFourOfAKind_ShouldReturnNoExceptions_False()
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
        public void PokerHandsCheckerIsFourOfAKind_ShouldReturnNoExceptions_False2()
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
