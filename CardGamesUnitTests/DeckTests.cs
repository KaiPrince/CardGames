using CardGames;
using CardGames.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGamesUnitTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void CreateADeck()
        {
            // Arrange
            Deck deck = new Deck();

            // Act

            // Assert
            Assert.AreEqual(deck.cards.Count, 52);
        }
    }
}