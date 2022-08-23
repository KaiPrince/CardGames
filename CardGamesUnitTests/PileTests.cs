using CardGames;
using CardGames.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGamesUnitTests
{
    [TestClass]
    public class PileTests
    {
        [TestMethod]
        public void CreateAPile()
        {
            // Arrange
            Pile pile = new Pile(){ new Card(Suit.Spades, Value.Ace) };

            // Act

            // Assert
            Assert.AreEqual(pile.Count, 1);
        }

        [TestMethod]
        public void DrawOne()
        {
            // Arrange
            var card = new Card(Suit.Spades, Value.Ace);
            Pile pile = new Pile() { card };

            // Act
            var result = pile.Draw();

            // Assert
            Assert.AreEqual(card, result);
            Assert.AreEqual(pile.Count, 0);
        }
        
        [TestMethod]
        public void DrawTwo()
        {
            // Arrange
            var cards = new List<Card>() { new Card(Suit.Spades, Value.Ace), new Card(Suit.Hearts, Value.King) };
            Pile pile = new Pile(cards);

            // Act
            var result = pile.Draw(2);

            // Assert
            Assert.AreEqual(cards[0], result[0]);
            Assert.AreEqual(cards[1], result[1]);
            Assert.AreEqual(pile.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OverDrawOne()
        {
            // Arrange
            var cards = new List<Card>() { };
            Pile pile = new Pile(cards);

            // Act
            var result = pile.Draw();

            // Assert
            Assert.Fail(); // Should not reach this point.
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OverDrawMany()
        {
            // Arrange
            var cards = new List<Card>() { new Card(Suit.Spades, Value.Ace), new Card(Suit.Hearts, Value.King) };
            Pile pile = new Pile(cards);

            // Act
            pile.Draw(3);

            // Assert
            Assert.Fail(); // Should not reach this point.
        }
    }
}