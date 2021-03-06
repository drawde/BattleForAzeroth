﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class IronbeakOwl : BaseServant
    {
        public override string CardCode => "038";
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage => 2;
        public override int InitialLife => 1;
        public override int InitialCost => 1;

        public override int BuffLife { get; set; } = 1;

        public override string Describe => "战吼：沉默一个随从";

        public override Rarity Rare => Rarity.普通;

        public override ICardAbility CardAbility { get; internal set; } = new AllServantBattlecryDriver<Silence<PrimaryServantFilter>>();

        public override string BackgroudImage => "W4_280_D.png";

        public override string Name => "铁喙猫头鹰";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.野兽;
    }
}
