namespace CardGames.Domain
{
    public class Card
    {
        public Card(Suit suit, Value value)
        {
            Suit = suit;
            Value = value;
        }

        public Suit Suit { get; }
        public Value Value { get; }
        public Color Color {
            get {
                return redSuits.Contains(Suit) ? Color.Red : Color.Black;
            }
        }

        private static readonly List<Suit> redSuits = new List<Suit>() { Suit.Hearts, Suit.Diamonds };

        public override bool Equals(object? obj)
        {
            return obj is Card card &&
                   Suit == card.Suit &&
                   Value == card.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Suit, Value);
        }
    }
}