﻿using BattleForAzeroth.Game.Util;
using System.Collections.Generic;
using System.Linq;
using BattleForAzeroth.Game.CardLibrary.Spell.Neutral.Classical;

using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.CardAction.Controler;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 开局换牌
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="lstInitCardIndex"></param>        
        public void SwitchCard(string userCode, List<int> lstInitCardIndex, IShortCodeService shortCodeService)
        {
            UserContext uc = GameContext.Players.First(c => c.Player.UserCode == userCode);
            
            if (lstInitCardIndex != null && lstInitCardIndex.Count > 0)
            {
                List<int> newIdx = RandomUtil.CreateRandomInt(0, uc.StockCards.Count() - 1, lstInitCardIndex.Count);
                newIdx = newIdx.OrderByDescending(c => c).ToList();
                foreach (int i in newIdx)
                {
                    uc.StockCards.ToList()[i].CardLocation = CardLocation.手牌;
                }
                lstInitCardIndex = lstInitCardIndex.OrderByDescending(c => c).ToList();
                foreach (int i in lstInitCardIndex)
                {                    
                    uc.InitCards.ToList()[i].CardLocation = CardLocation.牌库;
                }
            }
            else
            {
                uc.AllCards.Where(c => c.CardLocation == CardLocation.InitCard).ToList().ForEach(c => c.CardLocation = CardLocation.手牌);
            }



            //打乱牌库顺序
            int count = uc.AllCards.Count;
            List<int> newIndex = RandomUtil.CreateRandomInt(0, 100, count);
            newIndex.Sort(delegate (int a, int b) { return RandomUtil.CreateRandomInt(-1, 1); });
            for (int i = 0; i < newIndex.Count; i++)
            {
                uc.AllCards[i].Sort = newIndex[i];
            }

            uc.SwitchDone = true;

            //双方都换完牌后的流程
            if (GameContext.Players.First(c => c.Player.UserCode != userCode).SwitchDone)
            {
                var firstUser = GameContext.Players.First(c => c.IsFirst);
                //先手玩家换完牌后再抽一张牌
                var addCard = firstUser.StockCards.First();
                addCard.CardLocation = CardLocation.手牌;

                var secondUser = GameContext.Players.First(c => c.IsFirst == false);
                //后手玩家添加一枚幸运币
                var luckyCoin = new CreateNewCardInControllerAction<LuckyCoin>().Action(new ActionParameter() { GameContext = GameContext, UserContext = secondUser }) as LuckyCoin;
                luckyCoin.CardLocation = CardLocation.手牌;
                secondUser.IsActivation = false;

                TurnEnd(shortCodeService);
            }
            GameContext.Settlement();
        }
    }
}
