using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace RPS_Fighter.Displays
{
    class NewTurn
    {
        Sprite graphic;

        public NewTurn()
        {
            var tex = new Texture("Images/newturn.png");
            tex.Smooth = true;
            graphic = new Sprite(tex);
            graphic.Origin = new Vector2f(150, 400);
            graphic.Position = new Vector2f(150, 350);
        }

        bool rotateUp = true;
        public void Update()
        {
            if (rotateUp)
            {
                graphic.Rotation += 0.1f;
                if (graphic.Rotation > 5)
                {
                    rotateUp = false;
                }
            }
            else
            {
                graphic.Rotation -= 0.1f;
                if (graphic.Rotation < -5)
                {
                    rotateUp = true;
                }
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(graphic);
        }
    }
}
