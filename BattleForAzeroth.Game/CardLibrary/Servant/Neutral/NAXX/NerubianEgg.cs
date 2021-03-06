﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using BattleForAzeroth.Game.Widget.Filter.PickCard;
using BattleForAzeroth.Game.Widget.Number;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class NerubianEgg : BaseServant
    {
        public override string CardCode => "046";
        public override int Damage { get; set; } = 0;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage => 0;
        public override int InitialLife => 2;
        public override int InitialCost => 2;

        public override int BuffLife { get; set; } = 2;

        public override string Describe => "亡语：召唤一个4/4的蛛魔。";

        public override Rarity Rare => Rarity.精良;

        public override ICardAbility CardAbility { get; internal set; } = new DeathWhisperDriver<Summon<PrimaryUserContextFilter, AssignServantFilter<Nerubian>, ONE>, InDeskFilter>();

        public override string BackgroudImage => "NAXX/NerubianEgg.jpg";

        public override string Name => "蛛魔之卵";
        public override bool CanAttack => false;
        public override Profession Profession => Profession.Neutral;
    }
}
