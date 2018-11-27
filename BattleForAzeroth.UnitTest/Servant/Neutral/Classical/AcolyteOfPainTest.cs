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
using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game;

namespace BattleForAzeroth.UnitTest.Servant.Neutral.Classical
{

    public class AcolyteOfPainTest : BaseGameTest
    {
        public AcolyteOfPainTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        public void WhenInDesk()
        {
            AcolyteOfPain acolyteOfPain = InitNewCardInGame<AcolyteOfPain>();
            SetCardInDesk(acolyteOfPain);
            Card eviscerate = gameContext.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(Eviscerate));
            SetSomeCardInHand(eviscerate);

            List<Card> waittingDrawCards = gameContext.GetActivationUserContext().StockCards.Take(1).ToList();
            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, eviscerate.CardInGameCode, acolyteOfPain.DeskIndex) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(waittingDrawCards.All(c => c.CardLocation == CardLocation.手牌));
            Xunit.Assert.True(gameContext.GetActivationUserContext().HandCards.Count() == 1);
        }
    }
}
