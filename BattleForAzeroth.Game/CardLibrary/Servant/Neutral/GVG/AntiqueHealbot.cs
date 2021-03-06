﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.GVG
{
    public class AntiqueHealbot : BaseServant
    {
        public override string CardCode => "055";
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 5;

        public override int BuffLife { get; set; } = 3;
        public override string Describe => "战吼：为你的英雄恢复8点生命值。";

        public override Rarity Rare => Rarity.普通;

        public override ICardAbility CardAbility { get; internal set; } = new NoneTargetBattlecryDriver<Heal<PrimaryHeroFilter, Eight>>();

        public override string Name => "老式治疗机器人";
        public override Profession Profession => Profession.Neutral;

        public override Race Race => Race.机械;
        public override string BackgroudImage => "GVG/AntiqueHealbot.jpg";
    }
}
