﻿using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
using System.Linq;

namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant
{
    /// <summary>
    /// 随机选择副卡方随从
    /// </summary>
    public class RandomSecondaryServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            var targets = actionParameter.GameContext.DeskCards.GetDeskServantsByIsFirst(user.IsFirst).ToList();
            return new Func<Card, bool>(c => c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count() - 1)].CardInGameCode);
        }
    }
}
