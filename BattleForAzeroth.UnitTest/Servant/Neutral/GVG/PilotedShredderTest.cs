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
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.GVG;
using Newtonsoft.Json;
using BattleForAzeroth.Game.Util;

namespace BattleForAzeroth.UnitTest.Servant.Neutral.GVG
{

    public class PilotedShredderTest : BaseGameTest
    {

        public PilotedShredderTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetSharpswordOilCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        public void WhenDie()
        {
            PilotedShredder pilotedShredder1 = SetTestedCardInHand<PilotedShredder>();
            Card eviscerate = gameContext.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(Eviscerate));
            SetSomeCardInHand(eviscerate);

            GameResult<GameContextOutput> res = proxy.CastServant(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, pilotedShredder1.CardInGameCode, 1, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);

            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, eviscerate.CardInGameCode, pilotedShredder1.DeskIndex) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);

            Xunit.Assert.True(gameContext.GetActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == pilotedShredder1.CardInGameCode));
            Xunit.Assert.True(gameContext.DeskCards.Where(c => c != null).Count() == 3);
            Xunit.Assert.True(gameContext.DeskCards[3].Cost == 2);
        }
    }
}