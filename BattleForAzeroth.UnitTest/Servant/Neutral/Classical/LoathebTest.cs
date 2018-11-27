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
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.GVG;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.NAXX;
using BattleForAzeroth.Game.CardLibrary.Spell.Warlock;

namespace BattleForAzeroth.UnitTest.Spell.Rogue
{
    public class LoathebTest : BaseGameTest
    {

        public LoathebTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        public void WhenCastServant()
        {
            Loatheb loatheb = SetTestedCardInHand<Loatheb>();

            Card powerOverwhelming = gameContext.GetNotActivationUserContext().AllCards.First(c => c.GetType() == typeof(PowerOverwhelming));
            Card implosion = gameContext.GetNotActivationUserContext().AllCards.First(c => c.GetType() == typeof(Implosion));
            SetSomeCardInHand(powerOverwhelming, implosion);

            GameResult<GameContextOutput> res = proxy.CastServant(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, loatheb.CardInGameCode, 6, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(powerOverwhelming.Cost == 6);
            Xunit.Assert.True(implosion.Cost == 9);
        }

        [Fact]
        public void WhenEnemyTurnEnd()
        {
            Loatheb loatheb = SetTestedCardInHand<Loatheb>();

            Card powerOverwhelming = gameContext.GetNotActivationUserContext().AllCards.First(c => c.GetType() == typeof(PowerOverwhelming));
            Card implosion = gameContext.GetNotActivationUserContext().AllCards.First(c => c.GetType() == typeof(Implosion));
            SetSomeCardInHand(powerOverwhelming, implosion);

            GameResult<GameContextOutput> res = proxy.CastServant(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, loatheb.CardInGameCode, 6, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(powerOverwhelming.Cost == 6);
            Xunit.Assert.True(implosion.Cost == 9);

            res = proxy.TurnEnd(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, shortCodeService) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(powerOverwhelming.Cost == 6);
            Xunit.Assert.True(implosion.Cost == 9);

            res = proxy.TurnStart(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            res = proxy.TurnEnd(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, shortCodeService) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(powerOverwhelming.Cost == 1);
            Xunit.Assert.True(implosion.Cost == 4);
            Xunit.Assert.True(powerOverwhelming.Buffs.Any() == false);
            Xunit.Assert.True(implosion.Buffs.Any() == false);
        }
    }
}