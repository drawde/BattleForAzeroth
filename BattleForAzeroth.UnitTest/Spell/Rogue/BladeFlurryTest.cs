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

    public class BladeFlurryTest : BaseGameTest
    {

        public BladeFlurryTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]

        public void CastSpellFromUpgradeWeapon()
        {
            DeadlyPoison deadlyPoison = SetTestedCardInHand<DeadlyPoison>();
            BladeFlurry bladeFlurry = SetTestedCardInHand<BladeFlurry>();

            Voidwalker voidwalker = gameContext.GetNotActivationUserContext().AllCards.First(c => c.GetType() == typeof(Voidwalker)) as Voidwalker;
            SetCardInDesk(voidwalker);

            proxy.CastHeroPower(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, -1);
            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, deadlyPoison.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, bladeFlurry.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            BaseHero hero = gameContext.DeskCards[0] as BaseHero;
            Xunit.Assert.True(hero.Equip == null && gameContext.GetActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == bladeFlurry.CardInGameCode));
            BaseHero enemyHero = gameContext.DeskCards[8] as BaseHero;
            Xunit.Assert.True(enemyHero.Life == 27);
            Xunit.Assert.True(gameContext.GetNotActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == voidwalker.CardInGameCode));
        }

        [Fact]

        public void AttackedAndCastSpell()
        {
            BladeFlurry bladeFlurry = SetTestedCardInHand<BladeFlurry>();

            proxy.CastHeroPower(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, -1);                        

            BaseHero enemyHero = gameContext.DeskCards[8] as BaseHero;
            GameResult<GameContextOutput> res = proxy.HeroAttack(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, 8) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(enemyHero.Life == 29);

            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, bladeFlurry.CardInGameCode, -1) as GameResult<GameContextOutput>;
            BaseHero hero = gameContext.DeskCards[0] as BaseHero;
            Xunit.Assert.True(hero.Equip == null && gameContext.GetActivationUserContext().GraveyardCards.Any(c => c.CardInGameCode == bladeFlurry.CardInGameCode));
            Xunit.Assert.True(enemyHero.Life == 28);
        }
    }
}