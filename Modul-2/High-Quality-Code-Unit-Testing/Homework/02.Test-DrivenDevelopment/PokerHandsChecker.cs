using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const int ValidHandCardsCount = 5;
        public const int ValidFourOfAKindCards = 4;

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != ValidHandCardsCount)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var currentHand = hand.Cards[i];

                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    var cardToCheck = hand.Cards[j];

                    if (currentHand.Face == cardToCheck.Face && currentHand.Suit == cardToCheck.Suit)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            return hand.Cards.GroupBy(c => c.Face).
                Any(g => g.Count() == ValidFourOfAKindCards);

        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var currentHand = hand.Cards[i];

                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    var cardToCheck = hand.Cards[j];

                    if (currentHand.Suit != cardToCheck.Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
