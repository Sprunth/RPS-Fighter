using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace RPS_Fighter
{
    class RPSGame
    {
        RenderWindow window;
        public GameMaster GM { get; set; }
        Font font;

        public RPSGame()
        {
            ContextSettings cs = new ContextSettings();
            cs.AntialiasingLevel = 8;
            window = new RenderWindow(new VideoMode(1200,600),"RPS Fighter", Styles.Default, cs);
            window.Closed += window_Closed;
            window.SetFramerateLimit(60);
        }

        public void Initialize()
        {
            GM = new GameMaster();
            font = new Font("SegoeWP.ttf");
            
        }

        public void Run()
        {
            while(window.IsOpen())
            {
                Update();
                Draw();
            }
            window.Dispose();
        }

        private void Update()
        {
            window.DispatchEvents();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            { window.Close(); }
        }

        private void Draw()
        {
            window.Clear();
            //draw
            Text t = new Text("Hello World", font, 18);
            t.Position = new Vector2f(20, 30);
            window.Draw(t);
            window.Display();
        }

        void window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
