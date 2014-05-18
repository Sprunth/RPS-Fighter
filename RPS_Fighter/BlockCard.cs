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
            this.strength = strength;
            energyCost = 0;
            cardType = CardType.Block;
        }

    }
}
