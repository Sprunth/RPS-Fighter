using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace RPS_Fighter.Displays
{
    public class CardSelect
    {
        public List<CardDisplay> cards = new List<CardDisplay>();

        Sprite deckCard;
        CardDisplay discard;
        Card lastDiscardCard;

        Text deckLabel, discardLabel;
        Text gameStateStatus;

        Sprite background;

        Sprite hpBar1, mpBar1, hpBar2, mpBar2;
        Text hpLabel1, mpLabel1, hpLabel2, mpLabel2;

        public CardSelect(Character character)
        {
            Vector2f offset = new Vector2f(80, 90);
            Vector2u windowSize = Program.ActiveGame.WindowSize;
                float width = (windowSize.X * (2/3.0f))/4.0f;
                float height = windowSize.Y / 3;

            // 6 cards in hand max
            int handCount = (character.Hand.Count > 6) ? 6 : character.Hand.Count;
            for (int i = 0; i < handCount; i++)
            {
                CardDisplay cd = new CardDisplay();
                cd.UpdateInfo(character.Hand.GetCardOfIndex(i));
                cd.SetPosition(
                    new Vector2f(offset.X + width * ((i % 3)), offset.Y + height * ((i % 2)))
                    );
                cards.Add(cd);
            }
            deckCard = new Sprite(new Texture("Images/CardBack.png"));
            deckCard.Position = new Vector2f(windowSize.X - offset.X * 2, offset.Y);
            discard = new CardDisplay();
            lastDiscardCard = character.Discard.GetLastCard();
            if (lastDiscardCard != null)
            {
                discard.UpdateInfo(lastDiscardCard);
                discard.SetPosition(deckCard.Position + new Vector2f(0, height));
            }

            deckLabel = new Text("Deck", Program.ActiveGame.font, 28);
            discardLabel = new Text("Discard", Program.ActiveGame.font, 28);
            deckLabel.Position = new Vector2f(Program.ActiveGame.WindowSize.X - 160, 40);
            discardLabel.Position = new Vector2f(Program.ActiveGame.WindowSize.X - 160, Program.ActiveGame.WindowSize.Y - 130);

            string gameStateString = "";
            switch(GameMaster.ActiveGM.CurrentGameState)
            {
                case GameState.Player1Turn: { gameStateString = "Player 1's Turn"; break; }
                case GameState.Player2Turn: { gameStateString = "Player 2's Turn"; break; }
                case GameState.Combo: 
                    {
                        switch(GameMaster.ActiveGM.BattleResult)
                        {
                            case 0: // player 1 win
                                {
                                    gameStateString = "Player 1's combo phase";
                                    break;
                                }
                            case 1: // player 2 win
                                {
                                    gameStateString = "Player 2's combo phase";
                                    break;
                                }
                            case 2: // tie...should not reach here
                                {
                                    throw new Exception("Why is a tie entering combo?");
                                }
                        }
                        break;
                    }
            }
            gameStateStatus = new Text(gameStateString, Program.ActiveGame.font, 34);
            gameStateStatus.Position = new Vector2f(60, 20);

            background = new Sprite(new Texture("Images/GameMat2.png"));

            #region hpLabel mpLabel
            hpBar1 = new Sprite(new Texture("Images/HPBar.png"));
            mpBar1 = new Sprite(new Texture("Images/MPBar.png"));
            hpBar1.Scale = new Vector2f(1f, 0.1f);
            mpBar1.Scale = new Vector2f(1f, 0.1f);
            hpBar1.Position = new Vector2f(430, 20);
            mpBar1.Position = new Vector2f(430, 40);

            hpLabel1 = new Text(GameMaster.ActiveGM.Player1HP.ToString(), Program.ActiveGame.font, 14);
            mpLabel1 = new Text(GameMaster.ActiveGM.Player1MP.ToString(), Program.ActiveGame.font, 14);
            hpLabel1.Position = hpBar1.Position;
            mpLabel1.Position = mpBar1.Position;

            hpBar2 = new Sprite(new Texture("Images/HPBar.png"));
            mpBar2 = new Sprite(new Texture("Images/MPBar.png"));
            hpBar2.Scale = new Vector2f(1f, 0.1f);
            mpBar2.Scale = new Vector2f(1f, 0.1f);
            hpBar2.Position = new Vector2f(430, 540);
            mpBar2.Position = new Vector2f(430, 560);

            hpLabel2 = new Text(GameMaster.ActiveGM.Player2HP.ToString(), Program.ActiveGame.font, 14);
            mpLabel2 = new Text(GameMaster.ActiveGM.Player2MP.ToString(), Program.ActiveGame.font, 14);
            hpLabel2.Position = hpBar2.Position;
            mpLabel2.Position = mpBar2.Position;
            #endregion
        }

        public void Update()
        {
            foreach(CardDisplay disp in cards)
            {
                disp.Update();
            }
            #region hp/mp
            hpBar1.Scale = new Vector2f(GameMaster.ActiveGM.Player1HP / 30f, 0.1f);
            mpBar1.Scale = new Vector2f(GameMaster.ActiveGM.Player1MP / 15f, 0.1f);
            hpLabel1 = new Text(GameMaster.ActiveGM.Player1HP.ToString(), Program.ActiveGame.font, 14);
            mpLabel1 = new Text(GameMaster.ActiveGM.Player1MP.ToString(), Program.ActiveGame.font, 14);
            hpLabel1.Position = hpBar1.Position;
            mpLabel1.Position = mpBar1.Position;

            hpBar2.Scale = new Vector2f(GameMaster.ActiveGM.Player2HP / 30f, 0.1f);
            mpBar2.Scale = new Vector2f(GameMaster.ActiveGM.Player2MP / 15f, 0.1f);
            hpLabel2 = new Text(GameMaster.ActiveGM.Player2HP.ToString(), Program.ActiveGame.font, 14);
            mpLabel2 = new Text(GameMaster.ActiveGM.Player2MP.ToString(), Program.ActiveGame.font, 14);
            hpLabel2.Position = hpBar2.Position;
            mpLabel2.Position = mpBar2.Position;
            #endregion
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(background);

            foreach(CardDisplay cd in cards)
            {
                window.Draw(cd);
            }
            window.Draw(deckCard);
            if (lastDiscardCard != null)
            { window.Draw(discard); }

            window.Draw(deckLabel);
            window.Draw(discardLabel);
            window.Draw(gameStateStatus);

            window.Draw(hpBar1);
            window.Draw(mpBar1);
            window.Draw(hpLabel1);
            window.Draw(mpLabel1);

            window.Draw(hpBar2);
            window.Draw(mpBar2);
            window.Draw(hpLabel2);
            window.Draw(mpLabel2);
        }
    }
}
