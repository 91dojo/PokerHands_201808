﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_201808
{
    [TestClass]
    public class CardKindTests
    {
        private CardKindResolver _cardKindResolver;

        [TestMethod]
        public void Flush()
        {
            GivenCards("SA,S3,S4,S5,S6");
            ResultShouldBe(CardKind.Flush, 14);
        }

        [TestMethod]
        public void Straight()
        {
            GivenCards("S2,C3,D5,H4,H6");
            ResultShouldBe(cardKind: CardKind.Straight, maxPoint: 6);
        }

        [TestMethod]
        public void Straight_A2345()
        {
            GivenCards("S2,C3,D5,H4,HA");
            ResultShouldBe(CardKind.Straight, 14);
        }

        private void GivenCards(string cards)
        {
            _cardKindResolver = new CardKindResolver(cards);
        }

        private void ResultShouldBe(CardKind cardKind, int maxPoint)
        {
            Assert.AreEqual(cardKind, _cardKindResolver.GetKind());
            Assert.AreEqual(maxPoint, _cardKindResolver.MaxPoint);
        }
    }
}