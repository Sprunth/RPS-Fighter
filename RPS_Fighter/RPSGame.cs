using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

using RPS_Fighter.Displays;

namespace RPS_Fighter
{
    class RPSGame
    {
        public RenderWindow RPSWindow;
        public GameMaster GM { get; set; }
        public Font font { get; set; }
        public Vector2u WindowSize { get; set; }

        Cursor cursor;
        
        public RPSGame()
        {
            WindowSize = new Vector2u(1200, 600);
            ContextSettings cs = new ContextSettings();
            cs.AntialiasingLevel = 8;
            RPSWindow = new RenderWindow(new VideoMode(WindowSize.X, WindowSize.Y),"RPS Fighter", Styles.Titlebar | Styles.Close, cs);
            RPSWindow.Closed += window_Closed;
            RPSWindow.SetFramerateLimit(60);
        }

        public void Initialize()
        {
            font = new Font("Fonts/cambria.ttc");
            GM = new GameMaster();
            cursor = new Cursor();   
        }

        public void Run()
        {
            while(RPSWindow.IsOpen())
            {
                Update();
                Draw();
            }
            RPSWindow.Dispose();
        }

        private void Update()
        {
            RPSWindow.DispatchEvents();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            { RPSWindow.Close(); }

            cursor.Update();
        }

        private void Draw()
        {
            RPSWindow.Clear(new Color(20,30,40));
            //draw

            GM.Draw(RPSWindow);

            cursor.Draw(RPSWindow);

            RPSWindow.Display();
        }

        void window_Closed(object sender, EventArgs e)
        {
            RPSWindow.Close();
        }
    }
}
