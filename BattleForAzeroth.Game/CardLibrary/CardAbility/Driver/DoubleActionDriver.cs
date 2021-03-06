﻿using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 双技能驱动
    /// </summary>
    /// <typeparam name="G1"></typeparam>
    /// <typeparam name="G2"></typeparam>
    public class DoubleActionDriver<G1, G2, F> : BaseDriver<G1, F>, ICapture<F, IEvent> where G1 : IGameAction where G2 : IGameAction where F : ICardLocationFilter
    {
        public override IActionOutputParameter Action(ActionParameter actionParameter)
        {
            Activator.CreateInstance<G1>().Action(actionParameter);
            Activator.CreateInstance<G2>().Action(actionParameter);
            return null;
        }

        public override bool TryCapture(Card card, IEvent @event) => false;
    }
}
