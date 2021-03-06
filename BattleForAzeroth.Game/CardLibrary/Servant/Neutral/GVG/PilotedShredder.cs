﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.PickCard;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.GVG
{
    public class PilotedShredder : BaseServant
    {
        public override string CardCode => "052";
        public override int Damage { get; set; } = 4;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage => 4;
        public override int InitialLife => 3;
        public override int InitialCost => 4;

        public override int BuffLife { get; set; } = 3;

        public override string Describe => "亡语：增加召唤一个法力值消耗为（2）点的随从。";

        public override Rarity Rare => Rarity.精良;

        public override ICardAbility CardAbility { get; internal set; } = new DeathWhisperDriver<Summon<PrimaryUserContextFilter, RandomServantOfCostFilter<Two>, ONE>, InDeskFilter>();

        public override string BackgroudImage => "GVG/PilotedShredder.jpg";

        public override string Name => "载人收割机";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.机械;

    }
}
