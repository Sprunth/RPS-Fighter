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
        float p1yGoal, p2yGoal;

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

            p1Card = new CardDisplay();
            p2Card = new CardDisplay();
            p1Card.UpdateInfo(GameMaster.ActiveGM.P1Card);
            p2Card.UpdateInfo(GameMaster.ActiveGM.P2Card);
            p1Card.SetPosition(new Vector2f(-100, 80));
            p2Card.SetPosition(new Vector2f(Program.ActiveGame.WindowSize.X+100, Program.ActiveGame.WindowSize.Y-80));
            p1yGoal = 100;
            p2yGoal = Program.ActiveGame.WindowSize.X - 100;
        }

        public void Update()
        {
            if (!AnimationDone)
            {
                p1Card.SetPosition(p1Card.Position + new Vector2f(1, 0));
                p2Card.SetPosition(p2Card.Position + new Vector2f(-1, 0));
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(slash);
            window.Draw(versus);
            window.Draw(p1Card);
            window.Draw(p2Card);
        }

    }
}
