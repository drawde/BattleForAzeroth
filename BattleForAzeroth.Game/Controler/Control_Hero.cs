using BattleForAzeroth.Game.CardLibrary.Hero;

using System.Linq;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Equip;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAction.Equip;
using BattleForAzeroth.Game.Event.Player;
using BattleForAzeroth.Game.Event.Combo;

namespace BattleForAzeroth.Game.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 使用英雄技能
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        public void CastHeroPower(BaseHero hero, int target = -1)
        {
            var para = new ActionParameter()
            {
                GameContext = GameContext,
                PrimaryCard = hero,                
            };
            if (target > -1)
            {
                para.SecondaryCard = GameContext.DeskCards[target];
            }
            hero.CardAbility.Action(para);
            UserContext user = GameContext.GetUserContextByMyCard(hero);
            user.RemainingHeroPowerCastCount -= 1;
            user.Power -= hero.HeroPowerCost < 0 ? 0 : hero.HeroPowerCost;
            // GameContext.AddEndOfPlayerActionEvent();
            GameContext.Settlement();
            _gameCache.SetContext(GameContext);
        }

        /// <summary>
        /// 英雄攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>        
        public void HeroAttack(BaseHero hero, int target)
        {
            ActionParameter para = new ActionParameter()
            {
                PrimaryCard = hero,
                GameContext = GameContext,
                SecondaryCard = GameContext.DeskCards[target]
            };
            CardActionFactory.CreateAction(hero, ActionType.攻击).Action(para);
            // GameContext.AddEndOfPlayerActionEvent();
            GameContext.Settlement();
            _gameCache.SetContext(GameContext);
        }


        public void LoadEquip(BaseHero hero, BaseEquip equip)
        {
            var user = GameContext.GetUserContextByMyCard(hero);
            // user.ComboSwitch = true;
            user.Power -= equip.Cost < 0 ? 0 : equip.Cost;
            var equipPara = new ActionParameter()
            {
                GameContext = GameContext,
                PrimaryCard = equip,
                Equip = equip,
                Hero = hero,
            };
            new LoadAction().Action(equipPara);            
            GameContext.AddActionStatement(new ComboOnAction(), equipPara);
            GameContext.EventQueue.AddLast(new PrimaryPlayerPlayCardEvent() { EventCard = equip, Parameter = equipPara });
            // GameContext.AddEndOfPlayerActionEvent();
            GameContext.Settlement();
            _gameCache.SetContext(GameContext);
        }
    }
}
