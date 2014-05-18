using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class AttackCard : Card
    {
        public AttackCard(int strength, int energyCost) : base()
        {
            this.strength = strength;
            this.energyCost = energyCost;
            cardType = CardType.Attack;
        }

        public override void ApplyEffect(Character character)
        {
            character.HP -= strength;

            base.ApplyEffect(character);
        }
    }
}
