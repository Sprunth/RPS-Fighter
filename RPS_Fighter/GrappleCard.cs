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
            this.Strength = strength;
            this.EnergyCost = energyCost;
            TypeOfCard = CardType.Grapple;
        }

        public override void ApplyEffect(Character character)
        {
            character.HP -= Strength;

            base.ApplyEffect(character);
        }
    }
}
