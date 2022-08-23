using CardGames;
using CardGames.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGamesUnitTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CreateACard()
        {
            // Arrange
            Card card = new Card(Suit.Spades, Value.Ace);

            // Act

            // Assert
            Assert.AreEqual(card.Suit, Suit.Spades);
            Assert.AreEqual(card.Value, Value.Ace);
            Assert.AreEqual(card.Color, Color.Black);
        }

        [DataTestMethod]
        [DataRow(Suit.Spades, Color.Black)]
        [DataRow(Suit.Clubs, Color.Black)]
        [DataRow(Suit.Diamonds, Color.Red)]
        [DataRow(Suit.Hearts, Color.Red)]
        public void CardHasColor(Suit suit, Color color)
        {
            // Arrange
            Card card = new Card(suit, Value.Ace);

            // Act

            // Assert
            Assert.AreEqual(card.Suit, suit);
            Assert.AreEqual(card.Value, Value.Ace);
            Assert.AreEqual(card.Color, color);
        }
    }
}