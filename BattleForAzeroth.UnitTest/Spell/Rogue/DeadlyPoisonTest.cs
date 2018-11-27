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
using BattleForAzeroth.UnitTest;

namespace BattleForAzeroth.Spell.Servant.Rogue
{

    public class DeadlyPoisonTest : BaseGameTest
    {

        public DeadlyPoisonTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]

        public void CastSpell()
        {
            DeadlyPoison deadlyPoison = SetTestedCardInHand<DeadlyPoison>();
            proxy.CastHeroPower(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, -1);
            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, deadlyPoison.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            BaseHero hero = gameContext.DeskCards[0] as BaseHero;
            Xunit.Assert.True(hero.Equip.Damage == 3 && hero.Equip.Durable == 2);
        }
    }
}