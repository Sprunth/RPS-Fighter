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

        public Cursor()
        {
            tap = new Texture("Images/tap.png");
            tapClick = new Texture("Images/tapTick.png");

            cursor = new Sprite(tap);
        }

        public void Update()
        {
            Vector2i mousePos = Mouse.GetPosition(Program.ActiveGame.RPSWindow);
            cursor.Position = new Vector2f(mousePos.X, mousePos.Y);
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            { cursor.Texture = tapClick; }
            else
            { cursor.Texture = tap; }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(cursor);
        }
    }
}
