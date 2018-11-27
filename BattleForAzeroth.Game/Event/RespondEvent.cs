using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.Game.Event
{
    public abstract class RespondEvent
    {
        public virtual void Respond(IEvent @event)
        {
            GameContext gameContext = @event.Parameter.GameContext;
            // foreach (Card card in gameContext.AllCard.Where(c => c.CardInGameCode == "24"))
            // {
            //     bool res = card.CardAbility.TryCapture(card, @event);
            // }

            foreach (Card card in gameContext.AllCard.Where(c => c.CardAbility.TryCapture(c, @event)).OrderBy(c => c.CastIndex))
            {
                @event.Parameter.TertiaryCard = card;
                gameContext.AddActionStatements(card.CardAbility, @event.Parameter);
            }
            foreach (Card card in gameContext.AllCard.Where(c => c.Buffs.Count > 0).OrderBy(c => c.CastIndex))
            {
                @event.Parameter.TertiaryCard = card;
                LinkedListNode<IBuffRestore<ICardLocationFilter, IEvent>> buff = card.Buffs.First;
                while (buff != null && buff.Value.TryCapture(card, @event))
                {
                    gameContext.AddActionStatements(buff.Value, new ActionParameter
                    {
                        GameContext = @event.Parameter.GameContext,
                        PrimaryCard = card,
                        SecondaryCard = @event.EventCard,
                        TertiaryCard = card
                    });
                    card.Buffs.Remove(buff);
                    buff = buff.Next;                    
                }
            }
        }
    }
}
