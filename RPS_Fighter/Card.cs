using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    public class Card
    {
        static uint IDGen = 0;
        static uint GetUniqueID() { return IDGen++; }

        public uint uniqueID;

        public int Strength;
        public int EnergyCost;
        public CardType TypeOfCard;

        public Card()
        {
            uniqueID = GetUniqueID();
        }

        public virtual void ApplyEffect(Character character)
        {

        }

        public override string ToString()
        {
            return "Card with STR: " + Strength + " EnergyCost: " + EnergyCost + " Type: " + TypeOfCard;
        }
    }

    public enum CardType { Attack, Grapple, Block }
}
