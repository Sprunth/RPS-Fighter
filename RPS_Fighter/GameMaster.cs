using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPS_Fighter.Displays;
using SFML.Graphics;
using SFML.Window;

namespace RPS_Fighter
{
    class GameMaster
    {
        public static GameMaster ActiveGM { get { return Program.ActiveGame.GM; } }

        Character Player1 { get; set; }
        Character Player2 { get; set; }

        Card p1Card, p2Card;

        public GameState CurrentGameState { get; private set; }

        CardSelect cs;

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

            //test
            cs = new CardSelect(Player1.Hand);
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

        public void Draw(RenderWindow window)
        {
            cs.Draw(window);
        }

        public Character GetOtherCharacter(Character c)
        {
            return (c == Player1) ? Player2 : Player1;
        }

        //public void Player1Turn()
        //{
        //    int i = 0;
        //    while(true)
        //    {
        //        if(cs.cards[0].IsWithin(Mouse.GetPosition()))
        //        {

        //        }
        //    }
        //}
        /// <summary>
        /// Takes two cards and checks their types and values against each other. If one is superior to the other,
        /// then apply the superior card's effect to the inferior card's player, and declare the superior card's player
        /// as the victor. A zero is player 1's victory, and a 1 is player 2's victory, and a 2 means nobody wins.
        /// </summary>
        /// <returns></returns>
        public int Battle()
        {
            //check card strengths
            if ((p1Card.TypeOfCard == CardType.Attack) && (p2Card.TypeOfCard == CardType.Block))
                return 1; //
            else if ((p1Card.TypeOfCard == CardType.Block) && (p2Card.TypeOfCard == CardType.Grapple))
            {
                p2Card.ApplyEffect(Player1);
                return 1;
            }
            else if ((p1Card.TypeOfCard == CardType.Grapple) && (p2Card.TypeOfCard == CardType.Attack))
            {
                p2Card.ApplyEffect(Player1);
                return 1;
            }
            else if ((p2Card.TypeOfCard == CardType.Attack) && (p1Card.TypeOfCard == CardType.Block))
                return 0;
            else if((p2Card.TypeOfCard == CardType.Block) && (p1Card.TypeOfCard == CardType.Grapple))
            {
                p1Card.ApplyEffect(Player2);
                return 0;
            }
            else if((p2Card.TypeOfCard == CardType.Grapple) && (p1Card.TypeOfCard == CardType.Attack))
            {
                p1Card.ApplyEffect(Player2);
                return 0;
            }
            else if((p2Card.TypeOfCard == p1Card.TypeOfCard) &&(p1Card.TypeOfCard == CardType.Attack))
            {
                if(p1Card.Strength>p2Card.Strength)
                {
                    p1Card.ApplyEffect(Player2);
                    return 0;
                }
                else if(p2Card.Strength>p1Card.Strength)
                {
                    p2Card.ApplyEffect(Player1);
                    return 1;
                }
                else
                {
                    p1Card.ApplyEffect(Player2);
                    p2Card.ApplyEffect(Player1);
                    return 2;

                }
            }
            else if ((p2Card.TypeOfCard == p1Card.TypeOfCard) && (p1Card.TypeOfCard == CardType.Grapple))
            {
                if (p1Card.Strength > p2Card.Strength)
                {
                    p1Card.ApplyEffect(Player2);
                    return 0;
                }
                else if (p2Card.Strength > p1Card.Strength)
                {
                    p2Card.ApplyEffect(Player1);
                    return 1;
                }
                else
                {
                    p1Card.ApplyEffect(Player2);
                    p2Card.ApplyEffect(Player1);
                    return 2;

                }
            }
            return 2;
        }
        /// <summary>
        /// Resets player energies and checks health of players. If either is below zero, the other is the winner.
        /// If both of the players are under zero, then the match ends with a tie.
        /// 0 means player 1 wins, 1 means player 2 wins, 2 means a tie, and 3 means business as usual.
        /// </summary>
        /// <returns></returns>
        public int Reset()
        {
            Player1.CurEnergy = Player1.MaxEnergy;
            Player2.CurEnergy = Player2.MaxEnergy;
            if ((Player2.HP <= 0) && (Player1.HP <= 0))
                return 2;
            else if (Player2.HP <= 0)
                return 0;
            else if (Player1.HP <= 0)
                return 1;
            return 3;
        }
    }

    public enum GameState { Player1Turn, Player2Turn, Battle, Combo, Reset }
}
