using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace RPS_Fighter
{
    class CardDisplay : Drawable
    {
        RectangleShape rect;
        Text strength;
        Text energyCost;
        Text cardTypeText;
        Font font;

        public CardDisplay()
        {
            font = Program.ActiveGame.font;
        }

        public void UpdateText(Card c)
        {
            strength = new Text(c.Strength.ToString(), font);
            energyCost = new Text(c.EnergyCost.ToString(), font);
            cardTypeText = new Text(c.TypeOfCard.ToString(), font);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            
        }
    }
}
