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
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.GVG;
using System.Text;
using System.Collections.Generic;

namespace BattleForAzeroth.UnitTest.Spell.Rogue
{
    public class Tinker_sSharpswordOilTest : BaseGameTest
    {

        public Tinker_sSharpswordOilTest()
        {
            UserContext first = InitFirstUserContext(CardsUtil.GetSharpswordOilCards());
            UserContext second = InitSecondUserContext(CardsUtil.GetZooCards());
            InitGameContext(first, second, first.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero, second.AllCards.First(c => c.CardType == CardType.英雄) as BaseHero);
        }

        [Fact]
        public void WhenNoneCombo()
        {
            Tinker_sSharpswordOil tinker_sSharpswordOil = SetTestedCardInHand<Tinker_sSharpswordOil>();
            PilotedShredder pilotedShredder = gameContext.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(PilotedShredder)) as PilotedShredder;
            SetCardInDesk(pilotedShredder);
            BaseHero baseHero = gameContext.GetHeroByActivation();

            GameResult<GameContextOutput> res = proxy.CastHeroPower(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, tinker_sSharpswordOil.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);
            Xunit.Assert.True(baseHero.Equip.Damage == 4);
            Xunit.Assert.True(pilotedShredder.Damage == 4);
            Xunit.Assert.True(gameContext.GetActivationUserContext().ComboSwitch);
        }

        [Fact]
        public void WhenCombo()
        {
            Tinker_sSharpswordOil tinker_sSharpswordOil = SetTestedCardInHand<Tinker_sSharpswordOil>();
            PilotedShredder pilotedShredder = SetTestedCardInHand<PilotedShredder>();
            BaseHero baseHero = gameContext.GetHeroByActivation();

            GameResult<GameContextOutput> res = proxy.CastHeroPower(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);

            res = proxy.CastServant(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, pilotedShredder.CardInGameCode, 4, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);

            res = proxy.CastSpell(gameContext.GameCode, gameContext.GetActivationUserContext().UserCode, tinker_sSharpswordOil.CardInGameCode, -1) as GameResult<GameContextOutput>;
            Xunit.Assert.True(res.code == (int)OperateResCodeEnum.成功);

            Xunit.Assert.True(baseHero.Equip.Damage == 4);
            Xunit.Assert.True(pilotedShredder.Damage == 7);
        }

    }
}