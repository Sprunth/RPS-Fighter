using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class GameMaster
    {
        public static GameMaster ActiveGM { get { return Program.ActiveGame.GM; } }

        Character Player1 { get; set; }
        Character Player2 { get; set; }

        Card p1Card, p2Card;

        public Random Rand { get; set; }

        public GameMaster()
        {
            Rand = new Random();



            Player1 = new Character();
            Player2 = new Character();
        }

        public void SetPlayingCard(Card c, Character character)
        {
            if (Player1 == character)
            { p1Card = c; }
            else
            { p2Card = c; }
        }

        public Character GetOtherCharacter(Character c)
        {
            return (c == Player1) ? Player2 : Player1;
        }
    }
}
