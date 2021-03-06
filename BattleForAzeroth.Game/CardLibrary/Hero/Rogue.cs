﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Rogue : BaseHero
    {
        public override string CardCode => "017";
        public override string Name => "盗贼";
        public override Profession Profession => Profession.Rogue;
        public override ICardAbility CardAbility { get; internal set; } = new RogueAbility();
    }
}
