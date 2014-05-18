using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class Program
    {
        public static RPSGame ActiveGame { get; set; }

        public static Random Rand { get; set; }

        static void Main(string[] args)
        {
            Rand = new Random();

            DisplayTitleScreen();
            titleWindow.Dispose();

            ActiveGame = new RPSGame();
            ActiveGame.Initialize();
            ActiveGame.Run();
        }

        static RenderWindow titleWindow;

        static int page = 0;
        static Sprite title;

        private static void DisplayTitleScreen()
        {
            titleWindow = new RenderWindow(new SFML.Window.VideoMode(1200, 600), "RPS Fighter", SFML.Window.Styles.Close);
            titleWindow.MouseButtonReleased += window_MouseButtonReleased;
            titleWindow.SetMouseCursorVisible(false);
            title = new Sprite(new Texture("Images/TitleScreen3.png"));
            while (titleWindow.IsOpen())
            {
                titleWindow.DispatchEvents();
                titleWindow.Clear();
                titleWindow.Draw(title);
                titleWindow.Display();
            }
        }

        static void window_MouseButtonReleased(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            if (page == 0)
            {
                title = new Sprite(new Texture("Images/RulesPage3.png"));
                page++;
            }
            else
            {
                titleWindow.Close();
            }
        }
    }
}
