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
        Sprite spr, centerImg;
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

            string cardImagePath = "", cardCenterImagePath = "";
            switch(c.TypeOfCard)
            {
                case CardType.Attack:
                    {
                        cardImagePath = "Images/AttackFrontTemplate.png";
                        cardCenterImagePath = "Images/attack.png";
                        break;
                    }
                case CardType.Grapple:
                    {
                        cardImagePath = "Images/GrappleFrontTemplate.png";
                        cardCenterImagePath = "Images/grapple.png";
                        break;
                    }
                case CardType.Block:
                    {
                        cardImagePath = "Images/BlockFrontTemplate.png";
                        cardCenterImagePath = "Images/block.png";
                        break;
                    }
                default: throw new Exception("Unknown cardtype: " + c.TypeOfCard);
            }
            spr = new Sprite(new Texture(cardImagePath));
            centerImg = new Sprite(new Texture(cardCenterImagePath));
        }

        public void SetPosition(Vector2f pos)
        {
            spr.Position = pos;
            centerImg.Position = pos;
            strength.Position       = spr.Position + new Vector2f(16, 134);
            energyCost.Position     = spr.Position + new Vector2f(96, 134);
            cardTypeText.Position   = spr.Position + new Vector2f(12, 6);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = Transform.Identity;
            target.Draw(spr);
            target.Draw(centerImg);
            target.Draw(strength);
            target.Draw(energyCost);
            target.Draw(cardTypeText);
        }

        public bool IsWithin(Vector2f vector)
        {
            if ((vector.X >= spr.GetGlobalBounds().Left) &&
                (vector.X <= spr.GetGlobalBounds().Left + spr.GetGlobalBounds().Width) &&
                (vector.Y >= spr.GetGlobalBounds().Top) &&
                (vector.Y <= spr.GetGlobalBounds().Top + spr.GetGlobalBounds().Height))
            {
                return true;
            }
            return false;
        }
    }
}
