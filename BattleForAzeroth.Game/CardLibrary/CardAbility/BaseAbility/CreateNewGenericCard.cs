using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Event;
using System;
using System.Linq;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Context;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class CreateNewGenericCard<UC, C> : ICardAbility where UC : IUserContextFilter where C : Card
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            GameContext context = actionParameter.GameContext;
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                C card = Activator.CreateInstance<C>();
                card.IsFirstPlayerCard = user.IsFirst;
                //context.AllCard.Add(card);
                card.CardInGameCode = context.AllCard.Count().ToString();
                context.Players.First(c => c == user).AllCards.Add(card);

                if (user.HandCards.Count() < 10)
                {
                    //如果手牌没满则放入手牌中
                    //userContext.HandCards.Add(card);
                    card.CardLocation = CardLocation.手牌;
                }
                else
                {
                    //否则撕了这张牌
                    card.CardLocation = CardLocation.坟场;
                    //userContext.GraveyardCards.Add(card);
                }
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
