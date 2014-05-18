using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class Card
    {
        public int Strength;
        public int EnergyCost;
        public CardType TypeOfCard;

        public Card()
        {

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
