using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Domain
{
    public class Deck
    {
        public Deck()
        {
            cards = new Pile();
            
            // Add all cards (52)
            foreach (var suit in Enum.GetNames(typeof (Suit)))
            {
                foreach (var value in Enum.GetNames(typeof (Value)))
                {
                    cards.Add(new Card(Enum.Parse<Suit>(suit), Enum.Parse<Value>(value)));
                }
            }
        }

        public Pile cards;

    }
}
