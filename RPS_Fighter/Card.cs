using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class Card
    {
        protected int strength;
        protected int energyCost;
        protected CardType cardType;

        public Card()
        {

        }

        public virtual void ApplyEffect(Character character)
        {

        }

        public override string ToString()
        {
            return "Card with STR: " + strength + " EnergyCost: " + energyCost + " Type: " + cardType;
        }
    }

    public enum CardType { Attack, Grapple, Block }
}
