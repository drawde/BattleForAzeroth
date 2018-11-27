using BattleForAzeroth.Game;
using BattleForAzeroth.Game.Cache;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Controler.Proxy;
using BattleForAzeroth.Game.Model;
using BattleForAzeroth.Game.Util;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.UnitTest
{
    public class BaseGameTest
    {
        private int cardInGameIndex = 0;
        internal GameContext gameContext { get; set; }
        internal Controller_Base_Proxy proxy { get; set; }
        internal IShortCodeService shortCodeService = Substitute.For<IShortCodeService>();
        public UserContext InitSecondUserContext(List<Card> cardGroup)
        {
            shortCodeService.CreateCode().Returns(DateTime.Now.Ticks.ToString());
            PlayerModel secondPlayer = new PlayerModel()
            {
                UserCode = "secondPlayer",
            };
            UserContext second = new UserContext()
            {
                UserCode = secondPlayer.UserCode,
                Player = secondPlayer,
                IsActivation = false,
                IsFirst = false,
                AllCards = new List<Card>(),
                Power = 10,
                FullPower = 10,
                RemainingHeroPowerCastCount = 1,
                SwitchDone = true,
            };
            List<UserCardGroupDetailModel> secondCardGroup = new List<UserCardGroupDetailModel>();
            foreach (string cardCode in cardGroup.Select(c => c.CardCode))
            {
                secondCardGroup.Add(new UserCardGroupDetailModel() { CardCode = cardCode });
            }
            foreach (var cg in secondCardGroup)
            {
                Card libCard = CardsUtil.AllCard.First(c => c.CardCode == cg.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = false;
                second.AllCards.Add(card);
                cardInGameIndex++;
            }
            BaseHero secondHero = null;
            switch (second.AllCards.First(c => c.CardType == CardType.英雄).GetType().Name)
            {
                case "Druid": secondHero = new Druid(); break;
                case "Hunter": secondHero = new Hunter(); break;
                case "Mage": secondHero = new Mage(); break;
                case "Paladin": secondHero = new Paladin(); break;
                case "Priest": secondHero = new Priest(); break;
                case "Rogue": secondHero = new Rogue(); break;
                case "Shaman": secondHero = new Shaman(); break;
                case "Warlock": secondHero = new Warlock(); break;
                case "Warrior": secondHero = new Warrior(); break;
            }
            cardInGameIndex++;
            secondHero.CardLocation = CardLocation.场上;
            secondHero.CardInGameCode = cardInGameIndex.ToString();
            secondHero.DeskIndex = 8;
            secondHero.IsFirstPlayerCard = false;
            second.AllCards[second.AllCards.FindIndex(c => c.CardType == CardType.英雄)] = secondHero;
            return second;
        }
        public UserContext InitFirstUserContext(List<Card> cardGroup)
        {
            PlayerModel firstPlayer = new PlayerModel()
            {
                UserCode = "firstPlayer",
            };

            UserContext first = new UserContext()
            {
                UserCode = firstPlayer.UserCode,
                Player = firstPlayer,
                IsActivation = true,
                IsFirst = true,
                AllCards = new List<Card>(),
                Power = 10,
                FullPower = 10,
                RemainingHeroPowerCastCount = 1,
                SwitchDone = true,
            };

            List<UserCardGroupDetailModel> firstCardGroup = new List<UserCardGroupDetailModel>();
            foreach (string cardCode in cardGroup.Select(c => c.CardCode))
            {
                firstCardGroup.Add(new UserCardGroupDetailModel() { CardCode = cardCode });
            }

            foreach (var cg in firstCardGroup)
            {
                Card libCard = CardsUtil.AllCard.First(c => c.CardCode == cg.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = true;
                first.AllCards.Add(card);
                cardInGameIndex++;
            }

            BaseHero firstHero = null;
            switch (first.AllCards.First(c => c.CardType == CardType.英雄).GetType().Name)
            {
                case "Druid": firstHero = new Druid(); break;
                case "Hunter": firstHero = new Hunter(); break;
                case "Mage": firstHero = new Mage(); break;
                case "Paladin": firstHero = new Paladin(); break;
                case "Priest": firstHero = new Priest(); break;
                case "Rogue": firstHero = new Rogue(); break;
                case "Shaman": firstHero = new Shaman(); break;
                case "Warlock": firstHero = new Warlock(); break;
                case "Warrior": firstHero = new Warrior(); break;
            }

            cardInGameIndex++;
            firstHero.CardLocation = CardLocation.场上;
            firstHero.CardInGameCode = cardInGameIndex.ToString();
            firstHero.DeskIndex = 0;
            firstHero.IsFirstPlayerCard = true;
            first.AllCards[first.AllCards.FindIndex(c => c.CardType == CardType.英雄)] = firstHero;
            return first;
        }
        public void InitGameContext(UserContext first, UserContext second, BaseHero firstHero, BaseHero secondHero)
        {

            gameContext = new GameContext()
            {
                GameCode = "GameCode",
                CurrentTurnCode = "CurrentTurnCode",
                NextTurnCode = "NextTurnCode",
                Players = new List<UserContext> { first, second },
                GameStatus = GameStatus.进行中,
                TurnIndex = 10,
            };
            gameContext.DeskCards = new DeskBoard() { firstHero, null, null, null, null, null, null, null, secondHero, null, null, null, null, null, null, null };

            IGameCache gameCache = Substitute.For<IGameCache>();
            gameCache.GetAllCard().Returns(CardsUtil.AllCard);
            gameCache.GetContext(Arg.Any<string>()).Returns(gameContext);

            gameContext.GameCache = gameCache;
            proxy = new Controller_Base_Proxy(gameCache);
        }

        public C SetTestedCardInHand<C>() where C : Card
        {
            Card card = gameContext.GetActivationUserContext().AllCards.First(c => c.GetType() == typeof(C));
            card.CardLocation = CardLocation.手牌;
            return card as C;
        }

        public void SetSomeCardInHand(params Card[] args)
        {
            foreach (var card in args)
            {
                gameContext.GetUserContextByMyCard(card).AllCards.First(c => c.CardInGameCode == card.CardInGameCode).CardLocation = CardLocation.手牌;
            }
        }

        public T InitNewCardInGame<T>(bool IsActivation = true) where T : Card
        {
            T card = Activator.CreateInstance<T>();
            card.IsFirstPlayerCard = gameContext.Players.First(c => c.IsActivation == IsActivation).IsFirst;
            card.CardInGameCode = gameContext.AllCard.Count().ToString();
            gameContext.Players.First(c => c == gameContext.GetActivationUserContext()).AllCards.Add(card);
            return card;
        }

        public void SetCardInDesk(BaseBiology biology, int? deskIndex = null)
        {
            var userContext = gameContext.GetUserContextByMyCard(biology);
            if (deskIndex.HasValue == false)
            {
                deskIndex = userContext.IsFirst ? 4 : 12;
            }
            deskIndex = gameContext.AutoShiftServant(gameContext.ShiftServant(deskIndex.Value));
            biology.CardLocation = CardLocation.场上;
            biology.DeskIndex = deskIndex.Value;
            gameContext.DeskCards[deskIndex.Value] = biology;
        }
    }
}
