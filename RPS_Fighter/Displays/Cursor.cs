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
    class Cursor
    {
        Sprite cursor;

        Texture tap, tapClick;

        List<Sprite> stars;
        Texture star;

        public Cursor()
        {
            tap = new Texture("Images/tap.png");
            tapClick = new Texture("Images/tapTick.png");

            cursor = new Sprite(tap);

            stars = new List<Sprite>();
            star = new Texture("Images/starGold.png");
        }

        public void Update()
        {
            Vector2i mousePos = Mouse.GetPosition(Program.ActiveGame.RPSWindow);
            cursor.Position = new Vector2f(mousePos.X, mousePos.Y);
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            { cursor.Texture = tapClick; }
            else
            { cursor.Texture = tap; }

            Sprite newStar = new Sprite(star);
            newStar.Position = cursor.Position + new Vector2f(30,30);
            newStar.Scale = new Vector2f(0.6f, 0.6f);
            stars.Add(newStar);

            for (int i=0;i<stars.Count;i++)
            {
                stars[i].Scale = new Vector2f(stars[i].Scale.X * 0.9f, stars[i].Scale.Y * 0.9f);
                if (stars[i].Scale.X < 0.1f)
                    stars.RemoveAt(i);
            }
        }

        public void Draw(RenderWindow window)
        {
            foreach(Sprite s in stars)
            { window.Draw(s); }

            window.Draw(cursor);
            
        }
    }
}
