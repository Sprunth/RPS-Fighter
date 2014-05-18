using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace RPS_Fighter.Displays
{
    class WinScreen
    {
        Sprite background;
        Text winnerText;
        public WinScreen()
        {
            background = new Sprite(new Texture("Images/WinScreen.png"));
            winnerText = new Text();
        }
        public void DisplayWinner(int result)
        {
            switch(result)
            {
                case 0:
                    winnerText = new Text("Player 1 wins!", Program.ActiveGame.font, 50);
                    winnerText.Position = new Vector2f(Program.ActiveGame.WindowSize.X-750, 260);
                    break;
                case 1:
                    winnerText = new Text("Player 2 wins!", Program.ActiveGame.font, 50);
                    winnerText.Position = new Vector2f(Program.ActiveGame.WindowSize.X - 750, 260);
                    break;
                case 2:
                    winnerText = new Text("No one wins!", Program.ActiveGame.font, 50);
                    winnerText.Position = new Vector2f(Program.ActiveGame.WindowSize.X - 760, 260);
                    break;
            }
            winnerText.Color = new Color(0xd9, 0x29, 0x29);
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(background);
            window.Draw(winnerText);
        }
    }
}
