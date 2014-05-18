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
                cd.UpdateText(deck.GetCardOfIndex(i));
                Vector2u windowSize = Program.ActiveGame.WindowSize;
                float width = windowSize.X / 4;
                float height = windowSize.Y / 3;
                cd.SetPosition(new Vector2f(width * (i % 3), height * (i % 2)));
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
