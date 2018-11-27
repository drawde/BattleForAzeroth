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
    
    public class LootHoarderTest : BaseGameTest
    {

        public LootHoarderTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetSharpswordOilCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        
        public void WhenDie()
        {
            LootHoarder lootHoarder1 = gameContext.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(LootHoarder)) as LootHoarder;
            SetCardInDesk(lootHoarder1);
            lootHoarder1.CanAttack = true;
            lootHoarder1.RemainAttackTimes = 1;

            LootHoarder lootHoarder2 = gameContext.GetNotActivationUserContext().AllCards.First(c => c.GetType() == typeof(LootHoarder)) as LootHoarder;
            SetCardInDesk(lootHoarder2);

            Card firstCard = gameContext.GetActivationUserContext().StockCards.First();
            Card secondCard = gameContext.GetNotActivationUserContext().StockCards.First();

            Xunit.Assert.True(gameContext.GetActivationUserContext().HandCards.Count() == 0);
            Xunit.Assert.True(gameContext.GetNotActivationUserContext().HandCards.Count() == 0);
            GameResult<GameContextOutput> res = proxy.ServantAttack(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, lootHoarder1.CardInGameCode, 12) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(gameContext.GetActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == lootHoarder1.CardInGameCode));
            Xunit.Assert.True(gameContext.GetNotActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == lootHoarder2.CardInGameCode));
            Xunit.Assert.True(gameContext.GetActivationUserContext().HandCards.First().CardInGameCode == firstCard.CardInGameCode);
            Xunit.Assert.True(gameContext.GetNotActivationUserContext().HandCards.First().CardInGameCode == secondCard.CardInGameCode);
        }
    }
}