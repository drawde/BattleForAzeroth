using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event.Combo;

namespace BattleForAzeroth.Game.Action
{
    public class ComboOnAction : IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            actionParameter.GameContext.GetActivationUserContext().ComboSwitch = true;
            actionParameter.GameContext.EventQueue.AddLast(new TouchOffComboEvent() { Parameter = actionParameter });
            return null;
        }
    }
}
