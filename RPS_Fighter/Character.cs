using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    public class Character
    {
        public int HP { get; set; }
        public int MaxEnergy { get; private set; }
        public int CurEnergy { get; set; }
        public string Name { get; private set; }
        public Deck CDeck { get; set; }
        public Deck Hand { get; set; }
        public Deck Discard { get; set; }

        public Character(Deck initialDeck)
        {
            CDeck = initialDeck;
            Hand = new Deck();
            Discard = new Deck();
            for(int i=0;i<6;i++)
            {
                DrawCard();
            }

            HP = 30;
            MaxEnergy = 15;
        }

        public void DrawCard()
        {
            Card c = CDeck.Draw();
            Hand.AddCard(c); // TODO: Check that there aren't more than 6 cards in hand
        }

        public void PlayCard(Card c)
        {
            Hand.RemoveCard(c);
            Character enemy = GameMaster.ActiveGM.GetOtherCharacter(this);
            Program.ActiveGame.GM.SetPlayingCard(c, this);
            Discard.AddCard(c);
            if(CDeck.Count == 0)
            {
                CDeck = Discard;
                Discard = new Deck();
                CDeck.Shuffle();
            }
            DrawCard();
        }

        public void PlayCardCombo(Card c)
        {
            Hand.RemoveCard(c);
            Character enemy = GameMaster.ActiveGM.GetOtherCharacter(this);
            Program.ActiveGame.GM.SetPlayingCard(c, this);
            Discard.AddCard(c);
            if (CDeck.Count == 0)
            {
                CDeck = Discard;
                Discard = new Deck();
                CDeck.Shuffle();
            }
            //DrawCard();
        }

        public void DecreaseEnergy(Card c)
        {
            CurEnergy -= c.EnergyCost;
        }

        public void PrintDeck()
        {
            CDeck.PrintDeck();
        }

        public int HandCount { get { return Hand.Count; } }
    }
}
