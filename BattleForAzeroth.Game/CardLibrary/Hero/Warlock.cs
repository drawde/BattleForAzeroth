﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Warlock : BaseHero
    {
        public override string Name => "术士";
        public override Profession Profession => Profession.Warlock;
        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new WarlockAbility() };        
    }
}