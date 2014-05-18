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

        public RPSGame()
        {
            ContextSettings cs = new ContextSettings();
            cs.AntialiasingLevel = 8;
            window = new RenderWindow(new VideoMode(1200,900),"RPS Fighter", Styles.Default, cs);
            window.Closed += window_Closed;
        }

        public void Initialize()
        {
            GM = new GameMaster();
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
        }

        private void Draw()
        {
            window.Clear();
            //draw
            window.Display();
        }

        void window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
