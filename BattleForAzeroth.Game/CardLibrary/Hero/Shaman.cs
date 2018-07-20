﻿namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Shaman : BaseHero
    {
        public override string CardCode => "018";
        public override string Name => "萨满";
        public override Profession Profession => Profession.Shaman;
        public override bool IsEnable => false;
    }
}
