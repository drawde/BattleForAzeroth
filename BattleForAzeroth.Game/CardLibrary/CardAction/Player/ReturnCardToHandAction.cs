﻿using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Player
{
    /// <summary>
    /// 将一张牌返回到手牌（闷棍）
    /// </summary>
    public class ReturnCardToHandAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            int returnCount = actionParameter.ReturnCount;
            UserContext uc = actionParameter.UserContext;
            GameContext gameContext = actionParameter.GameContext;
            for (int i = 1; i <= returnCount; i++)
            {
                if (uc.HandCards.Count() < 10)
                {
                    //如果手牌没满则放入手牌中
                    actionParameter.PrimaryCard.CardLocation = CardLocation.手牌;
                    gameContext.DeskCards[gameContext.DeskCards.FindIndex(c => c != null && c.CardInGameCode == actionParameter.PrimaryCard.CardInGameCode)] = null;
                }
                else
                {
                    //否则标记这张牌为死亡
                    BaseBiology biology = actionParameter.PrimaryCard as BaseBiology;
                    biology.IsDeathing = true;                    
                }
            }
            return null;
        }
    }
}
