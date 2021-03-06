﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class DefenderOfArgus : BaseServant
    {
        public override string CardCode => "008";
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage => 2;
        public override int InitialLife => 3;
        public override int InitialCost => 4;

        public override int BuffLife { get; set; } = 3;
        public override string Describe => "战吼：使相邻的随从获得+1/+1和嘲讽。";

        public override Rarity Rare => Rarity.精良;

        public override ICardAbility CardAbility { get; internal set; } = 
        new NoneTargetBattlecryDriver
        <
            DoubleAbility
            <
                Taunt<PrimaryCardBothSidesFilter>,
                AddDamageAndLife<PrimaryCardBothSidesFilter, ONE, ONE, Plus, InDeskFilter>
            >
        >();


        public override string Name => "阿古斯防御者";
        public override string BackgroudImage => "W5_008_D.png";

        public override Profession Profession => Profession.Neutral;
    }
}
