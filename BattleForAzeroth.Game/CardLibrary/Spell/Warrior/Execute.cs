﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Condition.Assert.Injured;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Warrior
{
    public class Execute : BaseSpell
    {
        public override string CardCode => "036";
        public override Rarity Rare => Rarity.普通;

        public override string Name => "斩杀";
        public override int Cost { get; set; } = 1;
        public override int InitialCost => 1;
        public override string Describe => "消灭一个受过伤害的敌方随从。";

        public override ICardAbility CardAbility { get; internal set; } = new SpellDriver_Single_AllEnemyServant<Assert<SecondaryCardIsInjured, Death<SecondaryServantFilter>, NullAbility>>();

        public override string BackgroudImage => "WoW_Chi_061_D.png";
        public override Profession Profession => Profession.Warrior;
    }
}
