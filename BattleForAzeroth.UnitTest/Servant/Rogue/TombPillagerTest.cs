using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Spell.Rogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Xunit;
using BattleForAzeroth.Game.CardLibrary.Servant.Rogue;
using BattleForAzeroth.Game;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Controler.Proxy;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.TOC;
using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.CardLibrary.Servant.Warlock;
using BattleForAzeroth.Game.CardLibrary.Spell.Neutral.Classical;

namespace BattleForAzeroth.UnitTest.Servant.Rogue
{
    
    public class TombPillagerTest : BaseGameTest
    {

        public TombPillagerTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        
        public void WhenDie()
        {
            TombPillager TombPillager1 = gameContext.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(TombPillager)) as TombPillager;
            SetCardInDesk(TombPillager1);
            TombPillager1.CanAttack = true;
            TombPillager1.RemainAttackTimes = 1;

            FlameImp imp = gameContext.GetNotActivationUserContext().AllCards.First(c => c.GetType() == typeof(FlameImp)) as FlameImp;
            imp.Damage = 4;
            SetCardInDesk(imp);

            Card firstCard = gameContext.GetActivationUserContext().StockCards.First();

            Xunit.Assert.True(gameContext.GetActivationUserContext().HandCards.Count() == 0);
            Xunit.Assert.True(gameContext.GetNotActivationUserContext().HandCards.Count() == 0);
            GameResult<GameContextOutput> res = proxy.ServantAttack(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, TombPillager1.CardInGameCode, 12) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(gameContext.GetActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == TombPillager1.CardInGameCode));
            Xunit.Assert.True(gameContext.GetActivationUserContext().HandCards.First().GetType() == typeof(LuckyCoin));
        }
    }
}