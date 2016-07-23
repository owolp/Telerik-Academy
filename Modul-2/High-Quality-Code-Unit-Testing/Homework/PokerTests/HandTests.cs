namespace PokerTests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class HandTests
    {
        [Test]
        public void Hand_ToStringMethodShouldReturnNoExceptions()
        {
            var firstCard = new Card(CardFace.Ace, CardSuit.Clubs);
            var secondCard = new Card(CardFace.Eight, CardSuit.Diamonds);
            var expectedResult = string.Format($"{CardFace.Ace} of {CardSuit.Clubs}, {CardFace.Eight} of {CardSuit.Diamonds}");

            var listOfCard = new List<ICard>();
            listOfCard.Add(firstCard);
            listOfCard.Add(secondCard);

            var hand = new Hand(listOfCard);
            var actualResult = hand.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Hand_ShouldNotBeEqual_WhenThereIsNoEmptySpaceBetweenTheCards()
        {
            var firstCard = new Card(CardFace.Ace, CardSuit.Clubs);
            var secondCard = new Card(CardFace.Eight, CardSuit.Diamonds);
            var expectedResult = string.Format($"{CardFace.Ace} of {CardSuit.Clubs},{CardFace.Eight} of {CardSuit.Diamonds}");

            var listOfCard = new List<ICard>();
            listOfCard.Add(firstCard);
            listOfCard.Add(secondCard);

            var hand = new Hand(listOfCard);
            var actualResult = hand.ToString();

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        public void Hand_ShouldNotBeEqual_WhenThereIsNoCommaSpaceBetweenTheCards()
        {
            var firstCard = new Card(CardFace.Ace, CardSuit.Clubs);
            var secondCard = new Card(CardFace.Eight, CardSuit.Diamonds);
            var expectedResult = string.Format($"{CardFace.Ace} of {CardSuit.Clubs} {CardFace.Eight} of {CardSuit.Diamonds}");

            var listOfCard = new List<ICard>();
            listOfCard.Add(firstCard);
            listOfCard.Add(secondCard);

            var hand = new Hand(listOfCard);
            var actualResult = hand.ToString();

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }
}
