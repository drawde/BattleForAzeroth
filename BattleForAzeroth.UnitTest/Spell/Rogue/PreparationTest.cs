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

namespace BattleForAzeroth.UnitTest.Spell.Rogue
{
    public class PreparationTest : BaseGameTest
    {

        public PreparationTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        public void WhenCastSpell()
        {
            DeadlyPoison deadlyPoison = SetTestedCardInHand<DeadlyPoison>();
            BladeFlurry bladeFlurry = SetTestedCardInHand<BladeFlurry>();
            Preparation preparation = SetTestedCardInHand<Preparation>();
            Sprint sprint = SetTestedCardInHand<Sprint>();

            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, preparation.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(deadlyPoison.Cost == -2 && bladeFlurry.Cost == -1 && sprint.Cost == 4);
            Xunit.Assert.True(preparation.Cost == 0);
        }

        [Fact]
        public void WhenCastOtherSpell()
        {
            DeadlyPoison deadlyPoison = SetTestedCardInHand<DeadlyPoison>();
            BladeFlurry bladeFlurry = SetTestedCardInHand<BladeFlurry>();
            Preparation preparation = SetTestedCardInHand<Preparation>();
            Sprint sprint = SetTestedCardInHand<Sprint>();

            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, preparation.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, deadlyPoison.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(deadlyPoison.Cost == 1 && bladeFlurry.Cost == 2 && sprint.Cost == 7);
        }

        [Fact]
        public void WhenTurnEnd()
        {
            DeadlyPoison deadlyPoison = SetTestedCardInHand<DeadlyPoison>();
            BladeFlurry bladeFlurry = SetTestedCardInHand<BladeFlurry>();
            Preparation preparation = SetTestedCardInHand<Preparation>();
            Sprint sprint = SetTestedCardInHand<Sprint>();

            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, preparation.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            res = proxy.TurnEnd(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, shortCodeService) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(deadlyPoison.Cost == 1 && bladeFlurry.Cost == 2 && sprint.Cost == 7);
        }
    }
}