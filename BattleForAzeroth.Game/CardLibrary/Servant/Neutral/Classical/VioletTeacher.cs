﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using BattleForAzeroth.Game.Widget.Filter.PickCard;
using BattleForAzeroth.Game.Widget.Number;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class VioletTeacher : BaseServant
    {
        public override string CardCode => "009";
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage => 3;
        public override int InitialLife => 5;
        public override int InitialCost => 4;

        public override int BuffLife { get; set; } = 5;

        public override string Describe => "每当你施放一个法术时，召唤一个1/1的紫罗兰学徒。";

        public override Rarity Rare => Rarity.精良;

        public override ICardAbility CardAbility { get; internal set; } = new BeforeICastSpellDriver<Summon<PrimaryUserContextFilter, AssignServantFilter<VioletStudent>, ONE>, InDeskFilter>();


        public override string Name => "紫罗兰教师";

        public override string BackgroudImage => "W7_064_D.png";
        public override Profession Profession => Profession.Neutral;
    }
}
