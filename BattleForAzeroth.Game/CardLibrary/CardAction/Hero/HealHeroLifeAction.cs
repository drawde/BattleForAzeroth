﻿using System;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;


namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到治疗时，恢复它的生命值，然后触发随从或英雄受到治疗后的技能
    /// </summary>
    public class HealHeroLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            int heal = para.DamageOrHeal;
            baseHero.Life += heal;
            if (baseHero.Life > baseHero.BuffLife)
            {
                baseHero.Life = baseHero.BuffLife;
            }

            return null;
        }
    }
}
