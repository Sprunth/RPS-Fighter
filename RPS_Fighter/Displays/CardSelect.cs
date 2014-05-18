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
    public class CardSelect
    {
        public List<CardDisplay> cards = new List<CardDisplay>();

        Sprite deckCard;

        public CardSelect(Deck deck)
        {
            Vector2f offset = new Vector2f(80, 90);

            // 6 cards in hand max
            for (int i=0;i<6;i++)
            {
                CardDisplay cd = new CardDisplay();
                cd.UpdateInfo(deck.GetCardOfIndex(i));
                Vector2u windowSize = Program.ActiveGame.WindowSize;
                float width = (windowSize.X * (2/3.0f))/4.0f;
                float height = windowSize.Y / 3;

                
                cd.SetPosition(
                    new Vector2f(offset.X + width * ((i % 3)), offset.Y + height * ((i % 2)))
                    );
                cards.Add(cd);
            }
            deckCard = new Sprite(new Texture("Images/CardBack.png"));
            deckCard.Position = new Vector2f(Program.ActiveGame.WindowSize.X - offset.X * 2, offset.Y);
        }

        public void Draw(RenderWindow window)
        {
            foreach(CardDisplay cd in cards)
            {
                window.Draw(cd);
            }
            window.Draw(deckCard);
        }
    }
}
