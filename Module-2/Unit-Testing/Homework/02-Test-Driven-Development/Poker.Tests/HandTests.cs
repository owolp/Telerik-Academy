namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class HandTests
    {
        static object[] VerifyCasesThatAreTrue =
        {
        new object[] { new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Six, CardSuit.Diamonds), new Card(CardFace.Seven, CardSuit.Spades) },
        new object[] { new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) },
        };

        [Test, TestCaseSource("VerifyCasesThatAreTrue")]
        public void Hand_ToStringShouldReturnNoErrors(Card firstCard, Card secondCard, Card thirdCard)
        {
            var cards = new List<ICard>
            {
                firstCard,
                secondCard,
                thirdCard
            };
            var hand = new Hand(cards);

            var actual = hand.ToString();
            var expected = $"{firstCard.Face} of {firstCard.Suit}, {secondCard.Face} of {secondCard.Suit}, {thirdCard.Face} of {thirdCard.Suit}";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Hand_ToStringShouldReturnJustOneCard()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);
            var cards = new List<ICard> { card };
            var hand = new Hand(cards);

            var actual = hand.ToString();
            var expected = $"{card.Face} of {card.Suit}";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Hand_ToStringShouldReturnJustSpecialMessageThanThereAreNoCards_WhenThereAreNoCardsInTheHand()
        {
            var cards = new List<ICard>();
            var hand = new Hand(cards);

            var actual = hand.ToString();
            var expected = "No cards in hand!";

            Assert.AreEqual(expected, actual);
        }
    }
}
