using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class GrappleCard : Card
    {
        public GrappleCard(int strength, int energyCost) : base()
        {
            this.strength = strength;
            this.energyCost = energyCost;
            cardType = CardType.Grapple;
        }

        public override void ApplyEffect(Character character)
        {
            character.HP -= strength;

            base.ApplyEffect(character);
        }
    }
}
