using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class Character
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

        }

        public void PlayCard(Card c)
        {
            Hand.RemoveCard(c);
            Character enemy = GameMaster.ActiveGM.GetOtherCharacter(this);
            Program.ActiveGame.GM.SetPlayingCard(c, this);
            Discard.AddCard(c);
        }

        public void PrintDeck()
        {
            CDeck.PrintDeck();
        }
    }
}
