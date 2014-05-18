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

        public GameState CurrentGameState { get; private set; }

        public GameMaster()
        {
            Deck p1Deck = new Deck();
            Deck p2Deck = new Deck();
            p1Deck.StandardDeckPopulate();
            p2Deck.StandardDeckPopulate();

            Player1 = new Character(p1Deck);
            Player2 = new Character(p2Deck);

            Player1.PrintDeck();
            Player2.PrintDeck();

            CurrentGameState = GameState.Player1Turn;
        }

        public void SetPlayingCard(Card c, Character character)
        {
            if (Player1 == character)
            { p1Card = c; }
            else
            { p2Card = c; }
        }

        public void UpdateGameState()
        {
            switch(CurrentGameState)
            {
                case GameState.Battle:
                    CurrentGameState = GameState.Combo;
                    break;
                case GameState.Reset:
                    CurrentGameState = GameState.Player1Turn;
                    break;
            }
        }

        public Character GetOtherCharacter(Character c)
        {
            return (c == Player1) ? Player2 : Player1;
        }

        //public 
    }

    public enum GameState { Player1Turn, Player2Turn, Battle, Combo, Reset }
}
