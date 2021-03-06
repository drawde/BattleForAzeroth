﻿namespace BattleForAzeroth.Game.CardLibrary.Equip
{
    public class BaseEquip : Card
    {
        public override CardType CardType { get; set; } = CardType.装备;

        /// <summary>
        /// 耐久度
        /// </summary>
        public virtual int Durable { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public virtual int Damage { get; set; }        
        public virtual int InitialDamege { get; set; }
        public virtual int SpellPower { get; set; } = 0;
        public virtual bool HasWindfury { get; set; } = false;
        
    }
}
