﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Warrior
{
    public class InnerRage : BaseSpell
    {
        public override string CardCode => "034";
        public override Rarity Rare => Rarity.普通;

        public override string Name => "怒火中烧";
        public override int Cost { get; set; } = 0;
        public override int InitialCost => 0;
        public override string Describe => "对一个随从造成1点伤害，该随从获得+2攻击力。";
        public override int Damage { get; set; } = 1;
        public override ICardAbility CardAbility { get; internal set; } = new SpellDriver_Single_AllServant
                <
                    DoubleActionDriver
                    <
                        RiseDamage<SecondaryServantFilter, ONE, ONE, SpellDamage>,
                        AddDamage<SecondaryServantFilter, Two>, NullFilter
                    >>();

        public override string BackgroudImage => "W17_A197_D.png";
        public override Profession Profession => Profession.Warrior;
    }
}
