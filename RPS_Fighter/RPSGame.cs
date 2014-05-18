﻿using System;
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
        public Font font { get; set; }
        public Vector2u WindowSize { get; set; }

        public RPSGame()
        {
            WindowSize = new Vector2u(1200, 900);
            ContextSettings cs = new ContextSettings();
            cs.AntialiasingLevel = 8;
            window = new RenderWindow(new VideoMode(WindowSize.X, WindowSize.Y),"RPS Fighter", Styles.Titlebar | Styles.Close, cs);
            window.Closed += window_Closed;
            window.SetFramerateLimit(60);
        }

        public void Initialize()
        {
            GM = new GameMaster();
            font = new Font("Fonts/cambria.ttc");
            
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
            Text t = new Text("Hello World", font, 24);
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
