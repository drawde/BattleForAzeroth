﻿using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Event.Servant
{
    public class ServantInDeskEvent : RespondEvent, IEvent
    {
        public Card EventCard { get; set; }
        public ActionParameter Parameter { get; set; }
        public bool Compare(IEvent target) => target.GetType() == this.GetType();
        public void Settlement()
        {
            Respond(this);
        }
    }
}
