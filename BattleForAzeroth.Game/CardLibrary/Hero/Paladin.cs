using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Paladin : BaseHero
    {
        public override string CardCode => "015";
        public override string Name => "圣骑士";
        public override Profession Profession => Profession.Paladin;
        public override ICardAbility CardAbility { get; internal set; } = new PaladinAbility();
    }

}
