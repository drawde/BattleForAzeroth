using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Combo;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Combo
{
    /// <summary>
    /// 动态改变技能施放方式的连击驱动器
    /// </summary>
    /// <typeparam name="G1">无法触发连击时</typeparam>
    /// <typeparam name="G2">可以触发连击时</typeparam>
    public class DynamicCastCrosshairStyleComboDriver<G1, G2, F> : ComboDriver<G1, G2, F>, ICapture<F, TouchOffComboEvent>
    where F : ICardLocationFilter where G1 : IGameAction where G2 : IGameAction
    {
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;
        public string i { get; set; }
        public override bool TryCapture(Card card, IEvent @event)
        {
            TouchOffComboEvent touchOffComboEvent = Activator.CreateInstance<TouchOffComboEvent>();
            touchOffComboEvent.Parameter = @event.Parameter;
            bool isCapture = GameActivator<F>.CreateInstance().Filter(card) && touchOffComboEvent.Compare(@event);
            if (isCapture)
            {
                CastCrosshairStyle = CastCrosshairStyle.单个;
                
            }
            else
            {
                CastCrosshairStyle = CastCrosshairStyle.无;
            }
            
            return false;
        }
    }
}
