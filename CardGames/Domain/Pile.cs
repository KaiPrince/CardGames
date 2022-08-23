using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Domain
{
    public class Pile : List<Card>
    {
        public Pile()
        {
        }

        public Pile(IEnumerable<Card> collection) : base(collection)
        {
        }

        private static readonly Random rng = new Random();

        public void Shuffle()
        {
            int n = Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (this[n], this[k]) = (this[k], this[n]);
            }
        }

        public Card Draw()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No cards left in this pile.");
            }

            var card =  this.First();
            this.Remove(card);
            return card;
        }

        public List<Card> Draw(int count)
        {
            if (this.Count < count)
            {
                throw new InvalidOperationException($"Can't draw {count} cards from a pile of {this.Count}.");
            }

            var cards = this.Take(count).ToList();
            cards.ForEach(x => this.Remove(x));
            return cards;
        }
    }
}
