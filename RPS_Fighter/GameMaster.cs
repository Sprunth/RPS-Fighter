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
        /// <summary>
        /// Takes two cards and checks their types and values against each other. If one is superior to the other,
        /// then apply the superior card's effect to the inferior card's player, and declare the superior card's player
        /// as the victor. A zero is player 1's victory, and a 1 is player 2's victory.
        /// </summary>
        /// <returns></returns>
        public int Battle()
        {
            //check card strengths
            if ((p1Card.cardType == CardType.Attack) && (p2Card.cardType == CardType.Block))
                return 1; //
            else if ((p1Card.cardType == CardType.Block) && (p2Card.cardType == CardType.Grapple))
            {
                p2Card.ApplyEffect(Player1);
                return 1;
            }
            else if ((p1Card.cardType == CardType.Grapple) && (p2Card.cardType == CardType.Attack))
            {
                p2Card.ApplyEffect(Player1);
                return 1;
            }
            else if ((p2Card.cardType == CardType.Attack) && (p1Card.cardType == CardType.Block))
                return 0;
            else if((p2Card.cardType == CardType.Block) && (p1Card.cardType == CardType.Grapple))
            {
                p1Card.ApplyEffect(Player2);
                return 0;
            }
            else if((p2Card.cardType == CardType.Grapple) && (p1Card.cardType == CardType.Attack))
            {
                p1Card.ApplyEffect(Player2);
                return 0;
            }
        }
    }

    public enum GameState { Player1Turn, Player2Turn, Battle, Combo, Reset }
}
