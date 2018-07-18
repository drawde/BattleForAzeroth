﻿using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Event.GameProcess
{
    public class MyTurnStartEvent : RespondEvent, IEvent
    {
        public Card EventCard { get; set; }
        public ActionParameter Parameter { get; set; }

        public void Settlement()
        {
            Respond(this);
        }
    }
}