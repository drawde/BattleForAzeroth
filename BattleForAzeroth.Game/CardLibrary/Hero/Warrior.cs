using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Warrior : BaseHero
    {
        public override string CardCode => "020";
        public override string Name => "战士";
        public override Profession Profession => Profession.Warrior;
        public override ICardAbility CardAbility { get; internal set; } = new WarriorAbility();
    }
}
