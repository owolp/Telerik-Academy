﻿using System;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            if (this.Cards.Count == 0)
            {
                return "No cards in hand!";
            }

            return string.Join(", ", this.Cards);
        }
    }
}
