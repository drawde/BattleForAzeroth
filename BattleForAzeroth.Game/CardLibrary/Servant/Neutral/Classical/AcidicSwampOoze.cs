﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AcidicSwampOoze : BaseServant
    {
        public override string CardCode => "079";
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 2;


        public override int BuffLife { get; set; } = 2;
        public override string Describe => "战吼：摧毁你的对手的武器。";

        public override Rarity Rare => Rarity.精良;

        public override ICardAbility CardAbility { get; internal set; } = new NoneTargetBattlecryDriver<DestroyEquip<SecondaryHeroFilter>>();


        public override string Name => "酸性沼泽软泥怪";

        public override string BackgroudImage => "Classical/AcidicSwampOoze.jpg";

        public override Profession Profession => Profession.Neutral;

    }
}
