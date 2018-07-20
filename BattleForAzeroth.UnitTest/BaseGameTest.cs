using BattleForAzeroth.Game;
using BattleForAzeroth.Game.Cache;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.UnitTest
{
    public class BaseGameTest
    {
        CardsUtil cardsUtil = new CardsUtil();
        internal GameContext gameContext { get; set; }
        
        public void InitGameContext()
        {
            PlayerModel firstPlayer = new PlayerModel()
            {
                UserCode = "firstPlayer",
            };
            PlayerModel secondPlayer = new PlayerModel()
            {
                UserCode = "secondPlayer",
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

            List<UserCardGroupDetailModel> firstCardGroup = new List<UserCardGroupDetailModel>();
            foreach (string cardCode in cardsUtil.GetZooCards().Select(c => c.CardCode))
            {
                firstCardGroup.Add(new UserCardGroupDetailModel() { CardCode = cardCode });
            }
            List<UserCardGroupDetailModel> secondCardGroup = new List<UserCardGroupDetailModel>();
            foreach (string cardCode in cardsUtil.GetSharpswordOilCards().Select(c => c.CardCode))
            {
                secondCardGroup.Add(new UserCardGroupDetailModel() { CardCode = cardCode });
            }
            int cardInGameIndex = 0;
            foreach (var cg in firstCardGroup)
            {
                Card libCard = cardsUtil.AllCard.First(c => c.CardCode == cg.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardCode = libCard.CardCode;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = true;
                first.AllCards.Add(card);
                cardInGameIndex++;
            }
            foreach (var cg in secondCardGroup)
            {
                Card libCard = cardsUtil.AllCard.First(c => c.CardCode == cg.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardCode = libCard.CardCode;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = false;
                second.AllCards.Add(card);
                cardInGameIndex++;
            }

            BaseHero firstHero = null, secondHero = null;
            switch (first.AllCards.First(c=>c.CardType == CardType.英雄).GetType().Name)
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
            firstHero.CardCode = cardsUtil.AllCard.First(c => c.GetType().Name == firstHero.GetType().Name).CardCode;
            firstHero.CardInGameCode = cardInGameIndex.ToString();
            firstHero.DeskIndex = 0;
            firstHero.IsFirstPlayerCard = true;

            cardInGameIndex++;
            secondHero.CardCode = cardsUtil.AllCard.First(c => c.GetType().Name == secondHero.GetType().Name).CardCode;
            secondHero.CardInGameCode = cardInGameIndex.ToString();
            secondHero.DeskIndex = 8;
            secondHero.IsFirstPlayerCard = false;
            gameContext = new GameContext()
            {
                GameCode = "GameCode",
                CurrentTurnCode = "CurrentTurnCode",
                NextTurnCode = "NextTurnCode",
                Players = new List<UserContext> { first, second },
                GameStatus = GameStatus.进行中,
            };
            gameContext.DeskCards = new DeskBoard() { firstHero, null, null, null, null, null, null, null, secondHero, null, null, null, null, null, null, null };

            IGameCache gameCache = Substitute.For<IGameCache>();
            gameCache.GetAllCard().Returns(cardsUtil.AllCard);
            gameCache.GetContext(Arg.Any<string>()).Returns(gameContext);
            
            gameContext.GameCache = gameCache;
        }
    }
}
