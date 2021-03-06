﻿using BattleForAzeroth.Game.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game
{
    /// <summary>
    /// 游戏对象缓存器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameActivator<T> where T : IGameWidgetCache
    {
        private static List<T> Instances { get; set; } = new List<T>();

        public static T CreateInstance()
        {
            if (Instances.Any(c => c.GetType() == typeof(T)))
                return Instances.First(c => c.GetType() == typeof(T));

            T instance = Activator.CreateInstance<T>();
            if (instance.NoCache == false)
                Instances.Add(instance);
            return instance;
        }
    }
}
