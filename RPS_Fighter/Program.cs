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

            ActiveGame = new RPSGame();
            ActiveGame.Initialize();
            ActiveGame.Run();
        }
    }
}
