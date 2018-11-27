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
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Combo;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.UnitTest.Servant.Rogue
{

    public class SI7AgentTest : BaseGameTest
    {

        public SI7AgentTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        public void WhenInHand()
        {
            var context = gameContext;
            SI7Agent si7Agent = SetTestedCardInHand<SI7Agent>();
            Card eviscerate1 = context.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(Eviscerate));
            Card eviscerate2 = context.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(Eviscerate) && c.CardInGameCode != eviscerate1.CardInGameCode);
            SetSomeCardInHand(eviscerate1, eviscerate2);
            GameResult<GameContextOutput> res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, eviscerate1.CardInGameCode, 8) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            DynamicCastCrosshairStyleComboDriver<NullAbility, RiseDamage<SecondaryFilter, Two, ONE, PhysicalDamage>, NullFilter> driver =
            si7Agent.CardAbility as DynamicCastCrosshairStyleComboDriver<NullAbility, RiseDamage<SecondaryFilter, Two, ONE, PhysicalDamage>, NullFilter>;
            Xunit.Assert.True(driver.CastCrosshairStyle == CastCrosshairStyle.单个);
        }

        [Fact]
        public void WhenTurnEnd()
        {
            WhenInHand();
            GameResult<GameContextOutput> res = proxy.TurnEnd(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, shortCodeService) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            SI7Agent si7Agent = gameContext.Players.First(c => c.IsActivation == false).HandCards.First(c => c.GetType() == typeof(SI7Agent)) as SI7Agent;
            DynamicCastCrosshairStyleComboDriver<NullAbility, RiseDamage<SecondaryFilter, Two, ONE, PhysicalDamage>, NullFilter> driver =
            si7Agent.CardAbility as DynamicCastCrosshairStyleComboDriver<NullAbility, RiseDamage<SecondaryFilter, Two, ONE, PhysicalDamage>, NullFilter>;
            Xunit.Assert.True(driver.CastCrosshairStyle == CastCrosshairStyle.无);
        }
    }
}