﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warrior
{
    public class FrothingBerserker : BaseServant
    {
        public override string CardCode => "012";
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage => 2;
        public override int InitialLife => 4;
        public override int InitialCost => 3;


        public override int BuffLife { get; set; } = 4;
        public override string Describe => "每当一个随从受到伤害时，便获得+1攻击力。";

        public override Rarity Rare => Rarity.史诗;

        public override ICardAbility CardAbility { get; internal set; } = new BiologyHurtObserverDriver<AddDamage<PrimaryServantFilter, ONE>, InDeskFilter>();


        public override string Name => "暴乱狂战士";

        public override string BackgroudImage => "W6_222_D.png";

        public override Profession Profession => Profession.Warrior;
    }
}
