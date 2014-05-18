using SFML.Graphics;
using SFML.Window;
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
            DisplayInstrScreen();
            instrScreen.Dispose();

            ActiveGame = new RPSGame();
            ActiveGame.Initialize();
            ActiveGame.Run();
        }

        static RenderWindow titleWindow, instrScreen;

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

        private static void DisplayInstrScreen()
        {
            instrScreen = new RenderWindow(new SFML.Window.VideoMode(1200, 600), "RPS Fighter", SFML.Window.Styles.Close);
            instrScreen.MouseButtonReleased += window_MouseButtonReleasedi;
            instrScreen.SetMouseCursorVisible(false);
            Font fonts = new Font("Fonts/cambria.ttc");
            Text instr = new Text("Instructions:\n\nAt the beginning of each round, each player chooses a card to fight with. These cards are pitted against each other. The rules for\nvictory are simple: an Attack beats a Grapple, a Grapple beats a Block, and a Block beats an Attack. The rules become a little bit\nmore complex now.\n1. If you Block an Attack, you gain a small amount of health equal to the strength of your shield.\n2. If you Block another shield, you get a lessened amount of health.\n3. Grappling another grapples results in a test for control. The one with the higher Grapple strength will be victorious. If the two\ncards have equal strength, no damage is taken by either side.\n4. Similarly, Attacking an Attack also results in a struggle. The stronger Attack prevails. Equal-strength attacks result\nin both players losing health.\n5. A successful Grapple allows an extra action. A successful Attack allows for you to use as many attacks as your energy value\nallows, or until you choose a Block or Grapple card or run out of cards in your hand. Energy is replenished at the end of each round.\n", fonts, 22);
            instr.Position = new Vector2f(0, 0);
            while (instrScreen.IsOpen())
            {
                instrScreen.DispatchEvents();
                instrScreen.Clear();
                instrScreen.Draw(instr);
                instrScreen.Display();
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

        static void window_MouseButtonReleasedi(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            instrScreen.Close();
        }
    }
}
