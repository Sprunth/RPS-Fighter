using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class BlockCard : Card
    {
        public BlockCard(int strength) : base()
        {
            this.Strength = strength;
            EnergyCost = 0;
            TypeOfCard = CardType.Block;
        }

    }
}
