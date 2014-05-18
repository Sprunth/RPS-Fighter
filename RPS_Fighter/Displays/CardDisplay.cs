using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace RPS_Fighter.Displays
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
            strength = new Text(c.Strength.ToString(), font, 18);
            energyCost = new Text(c.EnergyCost.ToString(), font, 18);
            cardTypeText = new Text(c.TypeOfCard.ToString(), font, 18);

            
        }

        public void SetPosition(Vector2f pos)
        {
            rect = new RectangleShape(new Vector2f(128, 160));
            rect.Position = pos;
            rect.FillColor = new Color(110,100,90);
            rect.OutlineColor = new Color(24, 24, 24);
            rect.OutlineThickness = 2;
            strength.Position       = rect.Position + new Vector2f(8, 100);
            energyCost.Position     = rect.Position + new Vector2f(96, 100);
            cardTypeText.Position   = rect.Position + new Vector2f(2, 8);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(rect);
            target.Draw(strength);
            target.Draw(energyCost);
            target.Draw(cardTypeText);
        }

        public bool IsWithin(Vector2f vector)
        {
            if((vector.X >= rect.GetGlobalBounds().Left) && 
                (vector.X <= rect.GetGlobalBounds().Left + rect.GetGlobalBounds().Width) &&
                (vector.Y >= rect.GetGlobalBounds().Top) &&
                (vector.Y <= rect.GetGlobalBounds().Top + rect.GetGlobalBounds().Height))
            {
                return true;
            }
            return false;
        }
    }
}
