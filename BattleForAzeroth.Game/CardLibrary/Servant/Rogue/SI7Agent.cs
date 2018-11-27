using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Combo;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Rogue
{
    public class SI7Agent : BaseServant
    {
        public override string CardCode => "058";
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 3;

        public override int BuffLife { get; set; } = 3;
        public override string Describe => "连击：造成2点伤害。";

        public override Rarity Rare => Rarity.精良;

        public override ICardAbility CardAbility { get; internal set; } = new DynamicCastCrosshairStyleComboDriver<NullAbility, RiseDamage<SecondaryFilter, Two, ONE, PhysicalDamage>, NullFilter>();

        public override string Name => "军情七处特工";
        public override Profession Profession => Profession.Rogue;
        public override string BackgroudImage => "Classical/SI7Agent.jpg";
    }
}
