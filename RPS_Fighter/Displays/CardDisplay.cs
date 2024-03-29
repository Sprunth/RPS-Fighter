﻿using System;
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
    public class CardDisplay : Drawable
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

        public Card getCard()
        {
            return card;
        }

        public void UpdateInfo(Card c)
        {
            card = c;
            /*
            if (strength != null)
                strength.Dispose();
            if (energyCost != null)
                energyCost.Dispose();
            if (cardTypeText != null)
                cardTypeText.Dispose();
             * */
            strength = new Text("STR: " + c.Strength.ToString(), font, 16);
            energyCost = new Text("ENG: " + c.EnergyCost.ToString(), font, 16);
            cardTypeText = new Text(c.TypeOfCard.ToString(), font, 16);

            strength.Color = new Color(200, 200, 200);
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
            /*
            if (spr != null)
                spr.Dispose();
            if (centerImg != null)
                centerImg.Dispose();
             * */
            spr = new Sprite(new Texture(cardImagePath));
            centerImg = new Sprite(new Texture(cardCenterImagePath));
        }

        public void Update()
        {
            var mousePos = Mouse.GetPosition(Program.ActiveGame.RPSWindow);
            if (spr.GetGlobalBounds().Contains(mousePos.X, mousePos.Y))
            {
                spr.Color = new Color(255, 255, 255);
            }
            else { spr.Color = new Color(200, 200, 200); }
        }

        public void SetPosition(Vector2f pos)
        {
            spr.Position            = pos;
            centerImg.Position      = pos;
            strength.Position       = spr.Position + new Vector2f(14, 134);
            energyCost.Position     = spr.Position + new Vector2f(69, 134);
            cardTypeText.Position   = spr.Position + new Vector2f(12, 6);
        }
        public Vector2f Position { get { return spr.Position; } }

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
