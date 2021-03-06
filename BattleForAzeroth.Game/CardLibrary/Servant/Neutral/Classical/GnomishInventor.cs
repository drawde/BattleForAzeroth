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
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class GnomishInventor : BaseServant
    {
        public override string CardCode => "031";
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage => 2;
        public override int InitialLife => 4;
        public override int InitialCost => 4;


        public override int BuffLife { get; set; } = 4;
        public override string Describe => "战吼：抽一张牌。";

        public override Rarity Rare => Rarity.普通;

        public override ICardAbility CardAbility { get; internal set; } = new NoneTargetBattlecryDriver<DrawCard<PrimaryUserContextFilter, ONE>>();


        public override string Name => "侏儒发明家";
        public override string BackgroudImage => "W7_031_D.png";

        public override Profession Profession => Profession.Neutral;
    }
}
