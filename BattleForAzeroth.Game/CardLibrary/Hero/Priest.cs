namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Priest : BaseHero
    {
        public override string CardCode => "016";
        public override string Name => "牧师";
        public override Profession Profession => Profession.Priest;
        public override bool IsEnable => false;
    }
}
