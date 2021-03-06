﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class Whelp : BaseServant
    {
        public override string CardCode => "078";
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 1;
        public override int Cost { get; set; }  = 1;

        public override int InitialDamage => 1;
        public override int InitialLife => 1;
        public override int InitialCost => 1;


        public override int BuffLife { get; set; }  = 1;
        public override string Describe => "";

        public override Rarity Rare => Rarity.普通;

        public override string Name => "雏龙";
        public override string BackgroudImage => "Classical/Whelp.jpg";
        public override bool IsDerivative => true;
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.龙;
    }
}
