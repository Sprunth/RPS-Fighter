using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter.Displays
{
    class BattleScreen
    {
        Sprite slash, versus;

        public bool AnimationDone { get; private set; }

        CardDisplay p1Card, p2Card;

        public BattleScreen()
        {
            slash = new Sprite(new Texture("Images/BattleScreen.png"));
            var versusTex = new Texture("Images/versus.png");
            versusTex.Smooth = true;
            versus = new Sprite(versusTex);
            versus.Origin = new Vector2f(versusTex.Size.X/2, versusTex.Size.Y/2);
            versus.Rotation = -23;
            versus.Position = new Vector2f(versusTex.Size.X / 2, versusTex.Size.Y / 2 + 8);
            versus.Scale = new Vector2f(0.9f, 0.9f);

            AnimationDone = false;
        }

        public void Update()
        {

        }

        public void Draw(RenderWindow window)
        {
            window.Draw(slash);
            window.Draw(versus);
        }

    }
}
