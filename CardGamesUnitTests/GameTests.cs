using CardGames;
using CardGames.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGamesUnitTests
{
    [TestClass]
    public class GameTests
    {
        // Test with the rules of war: https://bargames101.com/war-card-game-rules/
        [TestMethod]
        public void SetUpAGame()
        {
            // Arrange
            Deck deck = new Deck();

            // Act
            deck.cards.Shuffle();
            Pile player1Deck = new Pile(deck.cards.Draw(26));
            Pile player2Deck = new Pile(deck.cards.Draw(26));

            // Assert
            Assert.AreEqual(deck.cards.Count, 0);
            Assert.AreEqual(player1Deck.Count, 26);
            Assert.AreEqual(player2Deck.Count, 26);
        }

        [TestMethod]
        public void PlayOneRound()
        {
            // Arrange
            Pile player1Deck = new Pile() { new Card(Suit.Clubs, Value.Two) };
            Pile player2Deck = new Pile(){ new Card(Suit.Spades, Value.Three) };

            // Act
            Card player1Card = player1Deck.Draw();
            Card player2Card = player2Deck.Draw();

            // ..Player2 wins
            player2Deck.Add(player1Card);
            player2Deck.Add(player2Card);


            // Assert
            Assert.AreEqual(player1Deck.Count, 0);
            Assert.AreEqual(player2Deck.Count, 2);
        }

    }
}