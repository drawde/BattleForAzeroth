﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event.GameProcess;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Spell;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class Loatheb : BaseServant
    {
        public override string CardCode => "054";
        public override int Damage { get; set; } = 5;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage => 5;
        public override int InitialLife => 5;
        public override int InitialCost => 5;

        public override int BuffLife { get; set; } = 5;
        public override string Describe => "战吼：下一回合敌方法术的法力值消耗增加（5）点。";

        public override Rarity Rare => Rarity.传说;

        public override ICardAbility CardAbility { get; internal set; } =
            new NoneTargetBattlecryDriver
            <
                ChangeCost
                <
                    PrimaryCardEnemySpell, Five, ONE, Plus, InHandFilter,
                    RestoreCost<PrimaryFilter, Five, ONE, Minus, NullFilter, MyTurnEndEvent
                    >
                >
            >();

        public override string Name => "洛欧塞布";
        public override Profession Profession => Profession.Neutral;
        public override string BackgroudImage => "NAXX/Loatheb.jpg";
    }
}
