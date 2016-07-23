namespace PokerTests
{
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class CardTests
    {
        [Test, Ignore("Just a test to show how to ignore Tests with Nunit")]
        public void TestShouldBeIgnored()
        {
        }

        [Test]
        public void Card_ToStringMethodShouldReturnNoExceptions()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.AreEqual(string.Format($"{CardFace.Ace} of {CardSuit.Clubs}"), card.ToString());
        }

        [Test]
        public void Card_ShouldNotBeEqual_WhenThereIsEmptySpaceBeforeTheCardFace()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.AreNotEqual(string.Format($" {CardFace.Ace} of {CardSuit.Clubs}"), card.ToString());
        }

        [Test]
        public void Card_ShouldNotBeEqual_WhenThereIsEmptySpaceAfterTheCardFace()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.AreNotEqual(string.Format($"{CardFace.Ace} of {CardSuit.Clubs} "), card.ToString());
        }
    }
}
