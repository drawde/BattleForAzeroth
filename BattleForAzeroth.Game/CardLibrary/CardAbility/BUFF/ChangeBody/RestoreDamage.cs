﻿using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using System;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Context;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class RestoreDamage<TAG, NUM, D, F, EVENT> : IBuffRestore<ICardLocationFilter, IEvent>, ICapture<ICardLocationFilter, IEvent>
        where TAG : IParameterFilter
        where NUM : INumber
        where D : IDirection
        where EVENT : IEvent
        where F : ICardLocationFilter
    {
        public Card MasterCard { get; set; }
        public RestoreDamage(Card masterCard) => MasterCard = masterCard;

        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            NUM num = GameActivator<NUM>.CreateInstance();
            D direction = Activator.CreateInstance<D>();
            F locationFilter = GameActivator<F>.CreateInstance();
            //ET et = GameActivator<ET>.CreateInstance();

            foreach (BaseBiology biology in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                biology.Damage += direction.SetNumber(num);

                //BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                //CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
            }
            return null;
        }

        public bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && Activator.CreateInstance<EVENT>().Compare(@event) && @event.Parameter.GameContext.IsThisActivationUserCard(card);
        }
    }
}
