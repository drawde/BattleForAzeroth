﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.Widget
{
    /// <summary>
    /// 表示该实例可以被缓存
    /// </summary>
    public interface IGameWidgetCache
    {
        bool NoCache { get; set; }
    }
}
