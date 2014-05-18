﻿using System;
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

        public Card P1Card, P2Card;

        public GameState CurrentGameState { get; private set; }

        CardSelect cs;
        BattleScreen bs;

        public int BattleResult { get; private set; }

        bool mouseClicked = false;

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

            cs = new CardSelect(Player1);
            bs = new BattleScreen();

            Program.ActiveGame.RPSWindow.MouseButtonReleased += RPSWindow_MouseButtonReleased;
        }

        void RPSWindow_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            mouseClicked = true;
        }

        public void SetPlayingCard(Card c, Character character)
        {
            if (Player1 == character)
            { P1Card = c; }
            else
            { P2Card = c; }
        }

        public void UpdateGameState()
        {
            switch(CurrentGameState)
            {
                case GameState.Player1Turn:
                    Player1Turn(Program.ActiveGame.RPSWindow);
                    break;
                case GameState.Player2Turn:
                    cs = new CardSelect(Player2);
                    Player2Turn(Program.ActiveGame.RPSWindow);
                    break;
                case GameState.Battle:
                    bs.Update();
                    if (bs.AnimationDone && mouseClicked)
                    {
                        mouseClicked = false;
                        bs.AnimationDone = false;
                        BattleResult = Battle();
                        switch (BattleResult)
                        {
                            case 0:
                                Console.WriteLine("Player One wins this round");
                                CurrentGameState = GameState.Combo;
                                break;
                            case 1:
                                Console.WriteLine("Player Two wins this round");
                                CurrentGameState = GameState.Combo;
                                break;
                            case 2:
                                Console.WriteLine("Glancing blows! A fierce battle!");
                                CurrentGameState = GameState.Reset;
                                break;
                            case 3:
                                Console.WriteLine("The fighters are frozen!");
                                CurrentGameState = GameState.Reset;
                                break;
                        }
                    }
                    break;
                case GameState.Combo:
                    CurrentGameState = GameState.Reset;
                    break;
                case GameState.Reset:
                    int resetVal = Reset();
                    switch(resetVal)
                    {
                        case 0:
                            Console.WriteLine("Player One is victorious! *fanfare*");
                            Player1.HP = 15;
                            Player2.HP = 15;
                            break;
                        case 1:
                            Console.WriteLine("Player Two has crushed the opposition! *hooray*");
                            Player2.HP = 15;
                            Player1.HP = 15;
                            break;
                        case 2:
                            Console.WriteLine("In war, there are no winners. *solemn music*");
                            Player1.HP = 15;
                            Player2.HP = 15;
                            break;
                        case 3:
                            Console.WriteLine("The battle continues! *Intense music*");
                            break;
                    }
                    CurrentGameState = GameState.Player1Turn;
                    cs = new CardSelect(Player1);
                    break;
            }
            
        }

        //public void Combo()
        //{
        //    if(P)
        //}

        public void Draw(RenderWindow window)
        {
            switch(CurrentGameState)
            {
                case GameState.Player1Turn:
                case GameState.Player2Turn:
                    { cs.Draw(window); break; }
                case GameState.Battle:
                    { bs.Draw(window); break; }
            }
        }

        public Character GetOtherCharacter(Character c)
        {
            return (c == Player1) ? Player2 : Player1;
        }

        public void Player1Turn(RenderWindow window)
        {
            //Console.WriteLine("Stuff");
            foreach (var item in cs.cards)
            {
                int x = Mouse.GetPosition(window).X;
                int y = Mouse.GetPosition(window).Y;
                Vector2f temp = new Vector2f((float)(x), (float)(y));
                if(item.IsWithin(temp) && mouseClicked)
                {
                    Console.WriteLine("Card chosen: " + item.getCard());
                    mouseClicked = false;
                    Player1.PlayCard(item.getCard());
                    CurrentGameState = GameState.Player2Turn;
                    break;
                }
            }
        }

        public void Player2Turn(RenderWindow window)
        {
            //Console.WriteLine("Stuff");
            foreach (var item in cs.cards)
            {
                int x = Mouse.GetPosition(window).X;
                int y = Mouse.GetPosition(window).Y;
                Vector2f temp = new Vector2f((float)(x), (float)(y));
                if (item.IsWithin(temp) && mouseClicked)
                {
                    Console.WriteLine("Card chosen: " + item.getCard());
                    mouseClicked = false;
                    Player2.PlayCard(item.getCard());
                    CurrentGameState = GameState.Battle;
                    bs.Initialize();
                    break;
                }
            }
        }
        /// <summary>
        /// Takes two cards and checks their types and values against each other. If one is superior to the other,
        /// then apply the superior card's effect to the inferior card's player, and declare the superior card's player
        /// as the victor. A zero is player 1's victory, and a 1 is player 2's victory, and a 2 means nobody wins.
        /// </summary>
        /// <returns></returns>
        public int Battle()
        {
            //check card strengths
            if ((P1Card.TypeOfCard == CardType.Attack) && (P2Card.TypeOfCard == CardType.Block))
                return 1; //
            else if ((P1Card.TypeOfCard == CardType.Block) && (P2Card.TypeOfCard == CardType.Grapple))
            {
                P2Card.ApplyEffect(Player1);
                Player2.DecreaseEnergy(P2Card);
                return 1;
            }
            else if ((P1Card.TypeOfCard == CardType.Grapple) && (P2Card.TypeOfCard == CardType.Attack))
            {
                P2Card.ApplyEffect(Player1);
                Player2.DecreaseEnergy(P2Card);
                return 1;
            }
            else if ((P2Card.TypeOfCard == CardType.Attack) && (P1Card.TypeOfCard == CardType.Block))
                return 0;
            else if((P2Card.TypeOfCard == CardType.Block) && (P1Card.TypeOfCard == CardType.Grapple))
            {
                P1Card.ApplyEffect(Player2);
                Player1.DecreaseEnergy(P1Card);
                return 0;
            }
            else if((P2Card.TypeOfCard == CardType.Grapple) && (P1Card.TypeOfCard == CardType.Attack))
            {
                P1Card.ApplyEffect(Player2);
                Player1.DecreaseEnergy(P1Card);
                return 0;
            }
            else if((P2Card.TypeOfCard == P1Card.TypeOfCard) && (P1Card.TypeOfCard == CardType.Attack))
            {
                if(P1Card.Strength>P2Card.Strength)
                {
                    P1Card.ApplyEffect(Player2);
                    Player1.DecreaseEnergy(P1Card);
                    return 0;
                }
                else if(P2Card.Strength>P1Card.Strength)
                {
                    P2Card.ApplyEffect(Player1);
                    Player2.DecreaseEnergy(P2Card);
                    return 1;
                }
                else
                {
                    P1Card.ApplyEffect(Player2);
                    P2Card.ApplyEffect(Player1);
                    return 2;

                }
            }
            else if ((P2Card.TypeOfCard == P1Card.TypeOfCard) && (P1Card.TypeOfCard == CardType.Grapple))
            {
                if (P1Card.Strength > P2Card.Strength)
                {
                    P1Card.ApplyEffect(Player2);
                    Player1.DecreaseEnergy(P1Card);
                    return 0;
                }
                else if (P2Card.Strength > P1Card.Strength)
                {
                    P2Card.ApplyEffect(Player1);
                    Player2.DecreaseEnergy(P2Card);
                    return 1;
                }
                else
                {
                    P1Card.ApplyEffect(Player2);
                    P2Card.ApplyEffect(Player1);
                    return 2;

                }
            }
            return 3;
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
