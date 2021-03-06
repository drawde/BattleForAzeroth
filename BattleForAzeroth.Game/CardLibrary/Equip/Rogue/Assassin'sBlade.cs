﻿namespace BattleForAzeroth.Game.CardLibrary.Equip.Rogue
{
    public class Assassin_sBlade : BaseEquip
    {
        public override string CardCode => "069";
        public override string Name => "刺客之刃";
        public override string BackgroudImage => "Classical/Assassin_sBlade.jpg";

        public override int Damage { get; set; } = 3;

        public override int InitialDamege => 3;
        public override int Durable { get; set; } = 4;
        public override int Cost { get; set; } = 5;
        public override int InitialCost => 5;
        public override string Describe => "";

        public override Profession Profession => Profession.Rogue;
    }
}
