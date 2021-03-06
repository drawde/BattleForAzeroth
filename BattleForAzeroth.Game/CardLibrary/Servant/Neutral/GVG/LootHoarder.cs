﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.GVG
{
    public class LootHoarder : BaseServant
    {
        public override string CardCode => "032";
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage => 2;
        public override int InitialLife => 1;
        public override int InitialCost => 2;


        public override int BuffLife { get; set; } = 1;
        public override string Describe => "亡语：抽一张牌。";

        public override Rarity Rare => Rarity.普通;

        public override ICardAbility CardAbility { get; internal set; } = new DeathWhisperDriver<DrawCard<PrimaryUserContextFilter, ONE>, InDeskFilter>();


        public override string Name => "战利品贮藏者";
        public override string BackgroudImage => "W9_A058_D.png";
        public override Profession Profession => Profession.Neutral;
    }
}
