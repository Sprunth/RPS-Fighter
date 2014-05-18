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
            this.Strength = strength;
            this.EnergyCost = energyCost;
            TypeOfCard = CardType.Attack;
        }

        public override void ApplyEffect(Character character)
        {
            character.HP -= Strength;

            base.ApplyEffect(character);
        }
    }
}
