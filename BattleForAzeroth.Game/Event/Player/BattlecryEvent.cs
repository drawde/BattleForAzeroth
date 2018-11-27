using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.CardAction.Servant;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Event.Player
{
    public class BattlecryEvent : RespondEvent, IEvent
    {
        public Card EventCard { get; set; }
        public ActionParameter Parameter { get; set; }
        public bool Compare(IEvent target) => target.GetType() == this.GetType();
        public void Settlement()
        {
            //CastServantAction action = new CastServantAction();
            //action.Action(Parameter);
            Respond(this);
        }
    }
}
