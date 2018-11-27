using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.Util
{
    public class GameResult<T> : APIResultBase
    {
        public T data { get; set; }
    }
}
