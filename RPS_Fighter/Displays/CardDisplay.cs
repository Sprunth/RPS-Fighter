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
        Sprite spr;
        Text strength;
        Text energyCost;
        Text cardTypeText;
        Font font;
        Card card;

        public CardDisplay()
        {
            font = Program.ActiveGame.font;
        }

        public void UpdateInfo(Card c)
        {
            card = c;
            strength = new Text(c.Strength.ToString(), font, 16);
            energyCost = new Text(c.EnergyCost.ToString(), font, 16);
            cardTypeText = new Text(c.TypeOfCard.ToString(), font, 16);

            strength.Color = new Color(32, 32, 32);
            energyCost.Color = strength.Color;
            cardTypeText.Color = strength.Color;

            string cardImagePath = "";
            switch(c.TypeOfCard)
            {
                case CardType.Attack: { cardImagePath = "Images/AttackFrontTemplate.png"; break; }
                case CardType.Grapple: { cardImagePath = "Images/GrappleFrontTemplate.png"; break; }
                case CardType.Block: { cardImagePath = "Images/BlockFrontTemplate.png"; break; }
                default: throw new Exception("Unknown cardtype: " + c.TypeOfCard);
            }
            spr = new Sprite(new Texture(cardImagePath));
        }

        public void SetPosition(Vector2f pos)
        {
            rect = new RectangleShape(new Vector2f(128, 160));
            rect.Position = pos;
            rect.FillColor = new Color(110,100,90);
            rect.OutlineColor = new Color(24, 24, 24);
            rect.OutlineThickness = 2;
            spr.Position = pos;
            strength.Position       = rect.Position + new Vector2f(16, 134);
            energyCost.Position     = rect.Position + new Vector2f(96, 134);
            cardTypeText.Position   = rect.Position + new Vector2f(12, 6);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = Transform.Identity;
            target.Draw(spr);
            //target.Draw(rect);
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
