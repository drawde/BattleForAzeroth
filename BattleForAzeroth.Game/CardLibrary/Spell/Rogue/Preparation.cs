using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event.GameProcess;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Spell;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Hybrid;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Rogue
{
    public class Preparation : BaseSpell
    {
        public override string CardCode => "065";
        public override Rarity Rare => Rarity.普通;

        public override string Name => "伺机待发";
        public override int Cost { get; set; } = 0;
        public override int InitialCost => 0;
        public override string Describe => "在本回合中，你所施放的下一个法术的法力值消耗减少（3）点。";

        public override ICardAbility CardAbility { get; internal set; } = new NoneTargetSpellDriver<
                    ChangeCost<PrimaryHandSpell, Three, ONE, Minus, InHandFilter,
                        RestoreCost<PrimaryFilter, Three, ONE, Plus, NullFilter, MyTurnEndOrBeforeICastSpell>>>();

        public override string BackgroudImage => "Classical/Preparation.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
