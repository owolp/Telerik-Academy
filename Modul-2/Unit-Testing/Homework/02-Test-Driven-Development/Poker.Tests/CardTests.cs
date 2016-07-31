namespace PokerTests
{
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class Class1
    {
        [TestCase(CardFace.Five, CardSuit.Clubs)]
        [TestCase(CardFace.Four, CardSuit.Hearts)]
        [TestCase(CardFace.Seven, CardSuit.Spades)]
        public void Card_ToStringShouldReturnNoErrors(CardFace cardFace, CardSuit cardSuit)
        {
            var card = new Card(cardFace, cardSuit);

            var actual = card.ToString();
            var expected = $"{cardFace} of {cardSuit}";

            Assert.AreEqual(expected, actual);
        }

        [TestCase(CardFace.Five, CardSuit.Clubs)]
        [TestCase(CardFace.Four, CardSuit.Hearts)]
        [TestCase(CardFace.Seven, CardSuit.Spades)]
        public void Card_ToStringShouldThrowArgumentException_WhenThereIsEmptySpaceBeforeTheCardFace(CardFace cardFace, CardSuit cardSuit)
        {
            var card = new Card(cardFace, cardSuit);

            var actual = card.ToString();
            var expected = string.Format($" {cardFace} of {cardSuit}");

            Assert.AreNotEqual(expected, actual);
        }

        [TestCase(CardFace.Five, CardSuit.Clubs)]
        [TestCase(CardFace.Four, CardSuit.Hearts)]
        [TestCase(CardFace.Seven, CardSuit.Spades)]
        public void Card_ToStringShouldThrowArgumentException_WhenThereIsEmptySpaceAfterTheCardFace(CardFace cardFace, CardSuit cardSuit)
        {
            var card = new Card(cardFace, cardSuit);

            var actual = card.ToString();
            var expected = string.Format($"{cardFace} of {cardSuit} ");

            Assert.AreNotEqual(expected, actual);
        }
    }
}
