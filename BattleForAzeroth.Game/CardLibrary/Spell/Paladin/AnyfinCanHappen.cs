﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Number;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using BattleForAzeroth.Game.Widget.Condition.RaceCondition;
using BattleForAzeroth.Game.Widget.Filter.PickCard;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Paladin
{
    public class AnyfinCanHappen : BaseSpell
    {
        public override string CardCode => "085";
        public override Rarity Rare => Rarity.精良;

        public override string Name => "亡者归来";
        public override int Cost { get; set; }  = 10;
        public override int InitialCost => 10;
        public override string Describe => "召唤七个在本局对战中死亡的鱼人。";

        public override ICardAbility CardAbility { get; internal set; } =
            new NoneTargetSpellDriver
            <
                Resurrection<PrimaryUserContextFilter, RaceCardFilter<Murloc>, RandomCardPickFilter<Seven>>
            >();

        public override string BackgroudImage => "Paladin/AnyfinCanHappen.jpg";
        public override Profession Profession => Profession.Paladin;
    }
}
