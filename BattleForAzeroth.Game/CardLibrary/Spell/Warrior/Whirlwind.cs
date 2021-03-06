﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Warrior
{
    public class Whirlwind : BaseSpell
    {
        public override string CardCode => "011";
        public override Rarity Rare => Rarity.普通;

        public override string Name => "旋风斩";
        public override int Cost { get; set; } = 1;
        public override int InitialCost => 1;
        public override string Describe => "对所有随从造成1点伤害。";

        public override ICardAbility CardAbility { get; internal set; } = new NoneTargetSpellDriver<RiseDamage<AllServantFilter, ONE, ONE, SpellDamage>>();

        public override string BackgroudImage => "W6_076_D.png";
        public override Profession Profession => Profession.Warrior;

        public override int Damage { get; set; } = 1;
    }
}
