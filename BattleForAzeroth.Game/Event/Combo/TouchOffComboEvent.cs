using System;
using System.Linq;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Event.GameProcess;
using BattleForAzeroth.Game.Event.Player;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
namespace BattleForAzeroth.Game.Event.Combo
{
    public class TouchOffComboEvent : RespondEvent, IEvent
    {
        public Card EventCard { get; set; }
        public ActionParameter Parameter { get; set; }
        public bool Compare(IEvent target)
        {
            return Parameter.GameContext.GetUserContextByMyCard(Parameter.PrimaryCard).ComboSwitch;
        }
        public void Settlement()
        {
            Respond(this);
        }
    }
}
