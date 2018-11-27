using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class NullAbility : ICardAbility
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
