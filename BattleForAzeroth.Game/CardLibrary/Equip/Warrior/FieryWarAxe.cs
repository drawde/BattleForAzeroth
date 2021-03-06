﻿using BattleForAzeroth.Game.CardLibrary.CardAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Equip.Warrior
{
    public class FieryWarAxe : BaseEquip
    {
        public override string CardCode => "044";
        public override string Name => "炽炎战斧";
        public override string BackgroudImage => "W14_a200_D.png";

        public override int Damage { get; set; }  = 3;
        
        public override int InitialDamege => 3;
        public override int Durable { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;
        public override int InitialCost => 2;
        public override string Describe => "";

        public override Profession Profession => Profession.Warrior;
    }
}
