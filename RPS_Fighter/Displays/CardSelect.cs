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
        List<CardDisplay> cards = new List<CardDisplay>();

        public CardSelect(Deck deck)
        {
            // 6 cards in hand max
            for (int i=0;i<6;i++)
            {
                CardDisplay cd = new CardDisplay();
                cd.UpdateInfo(deck.GetCardOfIndex(i));
                Vector2u windowSize = Program.ActiveGame.WindowSize;
                float width = (windowSize.X * (2/3.0f))/4.0f;
                float height = windowSize.Y / 3;

                Vector2f offset = new Vector2f(80, 90);
                cd.SetPosition(
                    new Vector2f(offset.X + width * ((i % 3)), offset.Y + height * ((i % 2)))
                    );
                cards.Add(cd);
            }
        }

        public void Draw(RenderWindow window)
        {
            foreach(CardDisplay cd in cards)
            {
                window.Draw(cd);
            }
        }
    }
}
