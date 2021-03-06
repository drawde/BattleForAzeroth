﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warlock
{
    public class Imp : BaseServant
    {
        public override string CardCode => "050";
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 1;
        public override int Cost { get; set; }  = 1;

        public override int InitialDamage => 1;
        public override int InitialLife => 1;
        public override int InitialCost => 1;
        
        public override int BuffLife { get; set; }  = 1;

        public override string Describe => "";

        public override Rarity Rare => Rarity.普通;

        public override string BackgroudImage => "Classical/Imp.jpg";
        public override bool IsDerivative => true;
        public override string Name => "小鬼";
        public override Profession Profession => Profession.Warlock;
        public override Race Race => Race.恶魔;
    }
}
