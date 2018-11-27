using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Spell.Rogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game;
using BattleForAzeroth.Game.Util;

namespace BattleForAzeroth.UnitTest.Servant.Neutral.Classical
{

    public class BloodmageThalnosTest : BaseGameTest
    {
        public BloodmageThalnosTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetSharpswordOilCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);

        }

        [Fact]
        public void WhenDie()
        {
            BloodmageThalnos bloodmageThalnos1 = SetTestedCardInHand<BloodmageThalnos>();
            bloodmageThalnos1.IsDeathing = true;

            Card firstCard = gameContext.GetActivationUserContext().StockCards.First();

            GameResult<GameContextOutput> res = proxy.CastServant(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, bloodmageThalnos1.CardInGameCode, 3, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(gameContext.GetActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == bloodmageThalnos1.CardInGameCode));
            Xunit.Assert.True(gameContext.GetActivationUserContext().HandCards.First().CardInGameCode == firstCard.CardInGameCode);
        }

        [Fact]
        public void SpellPowerTest()
        {
            Eviscerate Eviscerate = SetTestedCardInHand<Eviscerate>();
            BloodmageThalnos bloodmageThalnos = SetTestedCardInHand<BloodmageThalnos>();
            GameResult<GameContextOutput> res = proxy.CastServant(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, bloodmageThalnos.CardInGameCode, 3, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, Eviscerate.CardInGameCode, 8) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(gameContext.DeskCards[8].Life == 25);
        }
    }
}
