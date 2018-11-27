using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    public class PrimaryFilter : IParameterFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == actionParameter.PrimaryCard.CardInGameCode);
        }
    }
}
