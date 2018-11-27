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
using System.Collections;
using System.Collections.Generic;

namespace BattleForAzeroth.UnitTest.Servant.Neutral.GVG
{
    
    public class AntiqueHealbotTest : BaseGameTest
    {
        public static IEnumerable<object[]> InitTestData()
        {
            yield return new object[] { 20, 30, 28 };
            yield return new object[] { 25, 30, 30 };
            yield return new object[] { 25, 35, 33 };
        }
        public AntiqueHealbotTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetSharpswordOilCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        

        [Theory]
        [MemberData(nameof(InitTestData))]        
        public void WhenBattlecry(int life, int buffLife, int resultLife)
        {
            AntiqueHealbot antiqueHealbot = SetTestedCardInHand<AntiqueHealbot>();
            gameContext.DeskCards[0].Life = life;
            gameContext.DeskCards[0].BuffLife = buffLife;            
            GameResult<GameContextOutput> res = proxy.CastServant(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, antiqueHealbot.CardInGameCode, 1, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(gameContext.DeskCards[0].Life == resultLife);
        }
    }
}