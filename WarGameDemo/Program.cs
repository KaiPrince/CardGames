using CardGames.Domain;

// Play a game of War.
// The rules of war can be found at: https://bargames101.com/war-card-game-rules/

// Set up
Random random = new Random();
Deck deck = new Deck();
deck.cards.Shuffle();
Pile player1Deck = new Pile(deck.cards.Draw(26));
Pile player2Deck = new Pile(deck.cards.Draw(26));

List<Card> cardsInPlay = new List<Card>();
bool shouldDraw = false;
Card player1Card = player1Deck.Draw();
Card player2Card = player2Deck.Draw();

while (player1Deck.Count > 0 && player2Deck.Count > 0)
{
    // Play a round
    if (shouldDraw)
    {
        player1Card = player1Deck.Draw();
        player2Card = player2Deck.Draw();

        cardsInPlay.Add(player1Card);
        cardsInPlay.Add(player2Card);
    } else
    {
        shouldDraw = true;
    }

    Console.WriteLine($"Player1 drew {player1Card.Value} of {player1Card.Suit}.");
    Console.WriteLine($"Player2 drew {player2Card.Value} of {player2Card.Suit}.");

    bool tie = player1Card.Value == player2Card.Value;
    bool player1Wins = player1Card.Value > player2Card.Value;

    if (tie)
    {
        // Begin War.
        var player1IsDrawing = true;
        try
        {

            Pile player1Hand = new Pile(player1Deck.Draw(4));
            player1IsDrawing = false;
            Pile player2Hand = new Pile(player2Deck.Draw(4));

            cardsInPlay.AddRange(player1Hand);
            cardsInPlay.AddRange(player2Hand);

            // Both players pick cards at random because I'm too lazy for User Input.
            player1Hand.Shuffle();
            player2Hand.Shuffle();
            player1Card = player1Hand.Draw();
            player2Card = player2Hand.Draw();

            continue;
        } catch (InvalidOperationException e) { 
            Console.WriteLine(e.Message);
            if (player1IsDrawing)
            {
                player1Deck.Clear();
            } else
            {
                player2Deck.Clear();
            }
            break;
        }
    }
    else if (player1Wins)
    {
        Console.WriteLine($"Player1 gains {cardsInPlay.Count} cards.");
        player1Deck.AddRange(cardsInPlay);
        cardsInPlay.Clear();
    } else
    {
        Console.WriteLine($"Player2 gains {cardsInPlay.Count} cards.");
        player2Deck.AddRange(cardsInPlay);
        cardsInPlay.Clear();
    }
}

if (player1Deck.Count <= 0)
{
    Console.WriteLine("Player 2 wins!");
} else
{
    Console.WriteLine("Player 1 wins!");
}