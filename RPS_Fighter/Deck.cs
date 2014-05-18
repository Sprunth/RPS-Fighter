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

        public void StandardDeckPopulate()
        {
            List<Card> attack = new List<Card>();
            List<Card> grapple = new List<Card>();
            List<Card> block = new List<Card>();

            for (int i = 0; i < 5;i++ )
                attack.Add(new AttackCard(1, 1));
            for (int i = 0; i < 3; i++)
                attack.Add(new AttackCard(2, 2));
            for (int i = 0; i < 2; i++)
                attack.Add(new AttackCard(3, 4));
            attack.Add(new AttackCard(5, 8));

            for (int i = 0; i < 5; i++)
                grapple.Add(new GrappleCard(1, 1));
            for (int i = 0; i < 3; i++)
                grapple.Add(new GrappleCard(2, 2));
            for (int i = 0; i < 2; i++)
                grapple.Add(new GrappleCard(3, 4));
            grapple.Add(new GrappleCard(5, 8));

            for (int i = 0; i < 3; i++)
                block.Add(new BlockCard(4));
            for (int i = 0; i < 3; i++)
                block.Add(new BlockCard(5));
            block.Add(new BlockCard(6));

            for(int i=0;i<5;i++)
            {
                int index = Program.Rand.Next(attack.Count);
                Card c = attack[index];
                cards.Add(c);
                attack.RemoveAt(index);
            }
            for (int i = 0; i < 3; i++)
            {
                int index = Program.Rand.Next(grapple.Count);
                Card c = grapple[index];
                cards.Add(c);
                grapple.RemoveAt(index);
            }
            for (int i = 0; i < 3; i++)
            {
                int index = Program.Rand.Next(block.Count);
                Card c = block[index];
                cards.Add(c);
                block.RemoveAt(index);
            }
            // cards deck now has 5 atk, 3 grap, 3 blk
            this.Shuffle();
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
                int randomIndex = Program.Rand.Next(i + 1);

                //Swap elements
                cards[i] = cards[randomIndex];
                cards[randomIndex] = tmp;
            }
        }

        public void PrintDeck()
        {
            Console.WriteLine("Cards in deck: ");
            foreach (Card c in cards)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
