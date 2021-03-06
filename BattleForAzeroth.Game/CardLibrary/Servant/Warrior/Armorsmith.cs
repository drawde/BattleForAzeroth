﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.Context;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warrior
{
    public class Armorsmith : BaseServant
    {
        public override string CardCode => "033";
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage => 1;
        public override int InitialLife => 4;
        public override int InitialCost => 2;


        public override int BuffLife { get; set; } = 4;

        public override string Describe => "每当一个友方随从受到伤害，便获得1点护甲值。";

        public override Rarity Rare => Rarity.精良;

        public override ICardAbility CardAbility { get; internal set; } = new MyServantHurtObserverDriver<AddAmmo<PrimaryUserContextFilter, ONE>, InDeskFilter>();

        public override string BackgroudImage => "W10_A047_D.png";

        public override string Name => "铸甲师";
        public override Profession Profession => Profession.Warrior;
    }
}
