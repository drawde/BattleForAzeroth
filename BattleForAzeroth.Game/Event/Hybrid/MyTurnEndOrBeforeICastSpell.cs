using System;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Event.GameProcess;
using BattleForAzeroth.Game.Event.Player;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Event.Hybrid
{
    public class MyTurnEndOrBeforeICastSpell : RespondEvent, IEvent
    {
        public Card EventCard { get; set; }
        public ActionParameter Parameter { get; set; }
        public bool Compare(IEvent target)
        {
            Type type = target.GetType();
            return type == typeof(MyTurnEndEvent) || type == typeof(BeforeICastSpellEvent);
        }
        public void Settlement()
        {
            Respond(this);
        }
    }
}
