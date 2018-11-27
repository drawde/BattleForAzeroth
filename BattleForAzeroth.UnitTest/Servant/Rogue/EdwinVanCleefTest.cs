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
using BattleForAzeroth.Game.Util;

namespace BattleForAzeroth.UnitTest.Servant.Rogue
{

    public class EdwinVanCleefTest : BaseGameTest
    {

        public EdwinVanCleefTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        public void WhenInHand()
        {
            var context = gameContext;
            EdwinVanCleef edwinVanCleef = SetTestedCardInHand<EdwinVanCleef>();
            Card eviscerate1 = context.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(Eviscerate));
            Card eviscerate2 = context.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(Eviscerate) && c.CardInGameCode != eviscerate1.CardInGameCode);
            SetSomeCardInHand(eviscerate1, eviscerate2);
            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, eviscerate1.CardInGameCode, 8) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(edwinVanCleef.Life == 4);
            Xunit.Assert.True(edwinVanCleef.BuffLife == 4);
            Xunit.Assert.True(edwinVanCleef.Damage == 4);

            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, eviscerate2.CardInGameCode, 8) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(edwinVanCleef.Life == 6);
            Xunit.Assert.True(edwinVanCleef.BuffLife == 6);
            Xunit.Assert.True(edwinVanCleef.Damage == 6);
        }

        [Fact]
        public void WhenBuffRestore()
        {
            WhenInHand();
            GameResult<GameContextOutput> res = proxy.TurnEnd(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, shortCodeService) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            EdwinVanCleef edwinVanCleef = gameContext.Players.First(c => c.IsActivation == false).HandCards.First() as EdwinVanCleef;
            Xunit.Assert.True(edwinVanCleef.Life == 2);
            Xunit.Assert.True(edwinVanCleef.BuffLife == 2);
            Xunit.Assert.True(edwinVanCleef.Damage == 2);
        }
    }
}