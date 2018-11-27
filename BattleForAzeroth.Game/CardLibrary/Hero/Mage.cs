using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower;
using BattleForAzeroth.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Mage : BaseHero
    {
        public override string CardCode => "014";
        public override string Name => "法师";
        public override Profession Profession => Profession.Mage;
        public override ICardAbility CardAbility { get; internal set; } = new MageAbility();
        public override bool IsEnable => false;
    }
}
