﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.Util
{
    public enum APIResultCodeEnum
    {
        成功 = 100,
        签名验证失败 = 101,
        缺少参数 = 102,
        内部错误 = 103,
        查询不到需要的数据 = 110,
        登录失败 = 104,
        参数错误 = 105,
        不能提交重复数据 = 106,
        没有访问权限 = 107,
        用户名重复 = 108,
        手机号重复 = 109,
        邮箱重复 = 110,
        无法多开游戏 = 111,
        邀请码错误 = 112,
        验证码错误 = 113,
        用户名或密码错误 = 114,
    }
}
