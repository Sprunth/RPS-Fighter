using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class Deck
    {
        List<Card> cards;
        public Deck()
        {
            cards = new List<Card>();

        }

        

        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        public Card Draw()
        {
            Card c = cards.First();
            cards.Remove(c);
            return c;
        }

        public void RemoveCard(Card c)
        {
            cards.Remove(c);
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                Card tmp = cards[i];
                int randomIndex = GameMaster.ActiveGM.Rand.Next(i + 1);

                //Swap elements
                cards[i] = cards[randomIndex];
                cards[randomIndex] = tmp;
            }
        }
    }
}
