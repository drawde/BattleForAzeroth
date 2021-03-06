﻿using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF
{
    public interface IBuff<F, EVENT, RE> : ICardAbility where F : ICardLocationFilter where EVENT : IEvent where RE: IBuffRestore<ICardLocationFilter, IEvent>
    {
        Card MasterCard { get; set; }
        IBuffRestore<ICardLocationFilter, IEvent> BuffRestore { get; set; }
        //IActionOutputParameter Restore(BaseActionParameter actionParameter);
    }
}
