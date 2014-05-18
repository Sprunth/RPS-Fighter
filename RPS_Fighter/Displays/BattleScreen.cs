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

        public bool AnimationDone { get; set; }

        CardDisplay p1Card, p2Card;
        float p1Goal, p2Goal;
        Text p1, p2;

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

            p1 = new Text("Player 1", Program.ActiveGame.font, 42);
            p2 = new Text("Player 2", Program.ActiveGame.font, 42);
            p1.Position = new Vector2f(16, 4);
            p2.Position = new Vector2f(Program.ActiveGame.WindowSize.X - 160, Program.ActiveGame.WindowSize.Y - 56);
        }

        public void Initialize()
        {
            p1Card = new CardDisplay();
            p2Card = new CardDisplay();
            p1Card.UpdateInfo(GameMaster.ActiveGM.P1Card);
            p2Card.UpdateInfo(GameMaster.ActiveGM.P2Card);
            p1Card.SetPosition(new Vector2f(-100, 60));
            p2Card.SetPosition(new Vector2f(Program.ActiveGame.WindowSize.X, Program.ActiveGame.WindowSize.Y - 80*3));
            p1Goal = 190;
            p2Goal = Program.ActiveGame.WindowSize.X - 310;
        }

        public void Update()
        {
            if (!AnimationDone)
            {
                float speed = 7.6f;
                if (p1Card.Position.X < p1Goal)
                { p1Card.SetPosition(p1Card.Position + new Vector2f(speed, 0)); }

                if (p2Card.Position.X > p2Goal)
                { p2Card.SetPosition(p2Card.Position + new Vector2f(-speed, 0)); }

                if (p1Card.Position.X > p1Goal && p2Card.Position.X < p2Goal)
                { AnimationDone = true; }
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(slash);
            window.Draw(versus);
            window.Draw(p1Card);
            window.Draw(p2Card);
            window.Draw(p1);
            window.Draw(p2);
        }

    }
}
