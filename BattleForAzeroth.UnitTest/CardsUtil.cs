using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.CardLibrary.Spell.Neutral.Classical;
using BattleForAzeroth.Game.CardLibrary.Equip.Neutral.Classical;
using BattleForAzeroth.Game.CardLibrary.Servant.Warrior;
using BattleForAzeroth.Game.CardLibrary.Servant.Shaman.Classical;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.NAXX;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.BlackrockMountain;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.GVG;
using BattleForAzeroth.Game.CardLibrary.Equip.Warrior;
using BattleForAzeroth.Game.CardLibrary.Spell.Warrior;
using BattleForAzeroth.Game.CardLibrary.Servant.Warlock;
using BattleForAzeroth.Game.CardLibrary.Spell.Warlock;
using BattleForAzeroth.Game.CardLibrary.Servant.Rogue;
using BattleForAzeroth.Game.CardLibrary.Equip.Rogue;
using BattleForAzeroth.Game.CardLibrary.Spell.Rogue;
using BattleForAzeroth.Game.CardLibrary.Servant.Neutral.TOC;
using BattleForAzeroth.Game.CardLibrary.Servant.Paladin;
using BattleForAzeroth.Game.CardLibrary.Spell.Paladin;
using BattleForAzeroth.Game.CardLibrary.Equip.Paladin;
using BattleForAzeroth.Game.CardLibrary;

namespace BattleForAzeroth.UnitTest
{
    public class CardsUtil
    {
        public List<Card> AllCard => new List<Card>
            {
                new Hunter(),
                new Warlock(),
                new Al_akir(),//奥拉基
                new JiaoXiaoDeZhongShi(),
                new GuiLingZhiZhu(),
                new XiaoZhiZhu(),
                new LuckyCoin(),
                new DefenderOfArgus(),//阿古斯防御者
                new VioletTeacher(),//紫罗兰教师
                new VioletStudent(),
                new Whirlwind(),//旋风斩
                new FrothingBerserker(),//暴乱狂战士
                new KnifeJuggler(),//飞刀杂耍者
                new Mage(),
                new Paladin(),
                new Priest(),
                new Rogue(),
                new Shaman(),
                new Warrior(),
                new WarglaiveOfAzzinoth(),//埃辛诺斯战刃
                new IllidanStormrage(),//伊利丹
                new GrimPatron(),//恐怖奴隶主
                new Patchwerk(),//帕奇维克
                new WarsongCommander(),//战歌指挥官
                new SylvanasWindrunner(),//希尔瓦娜斯
                new EmperorThaurissan(),//索瑞森大帝
                new DeathBite(),//死亡之咬
                new AcolyteOfPain(),//苦痛恃僧
                new CruelTaskmaster(),//严酷的监工
                new GnomishInventor(),//侏儒发明家
                new LootHoarder(),//战利品贮藏者
                new Armorsmith(),//铸甲师
                new InnerRage(),//怒火中烧
                new BattleRage(),//战斗怒火
                new Execute(),//斩杀
                new ShieldBlock(),//盾牌格挡
                new IronbeakOwl(),//猫头鹰
                new BigGameHunter(),//王牌猎手
                new Slam(),//猛击
                new WildPyromancer(),//狂野炎术师
                new FlameImp(),//烈焰小鬼
                new Doomguard(),//末日守卫
                new FieryWarAxe(),//炽炎战斧
                new DireWolfAlpha(),//恐狼前锋
                new NerubianEgg(),//蛛魔之卵
                new Nerubian(),//蛛魔
                new PowerOverwhelming(),//力量的代价
                new ImpGangBoss(),//小鬼首领
                new Imp(),//小鬼
                new Implosion(),//小鬼爆破
                new PilotedShredder(),//载人收割机
                new Voidwalker(),//虚空行者
                new Loatheb(),//洛欧塞布
                new AntiqueHealbot(),//老式治疗机器人
                new EarthenRingFarseer(),//大地之环先知
                new EdwinVanCleef(),//艾德温·范克里夫
                new SI7Agent(),//军情七处特工
                new WickedKnife(),//邪恶短刀
                new BloodmageThalnos(),//血法师萨尔诺斯
                new Sap(),//闷棍
                new Vanish(),//消失
                new Eviscerate(),//刺骨
                new AzureDrake(),//碧蓝幼龙
                new Preparation(),//伺机待发
                new Sprint(),//疾跑
                new Backstab(),//背刺
                new FanofKnives(),//刀扇
                new Assassin_sBlade(),//刺客之刃
                new DeadlyPoison(),//致命药膏
                new Tinker_sSharpswordOil(),//修补匠的磨刀油
                new BladeFlurry(),//剑刃乱舞
                new LeeroyJenkins(),//火车王里诺艾
                new TombPillager(),//盗墓匪贼
                new KoboldGeomancer(),//狗头人地卜师
                new Doomsayer(),//末日预言者
                new MadBomber(),//疯狂投弹者
                new Whelp(),//雏龙
                new AcidicSwampOoze(),//酸性沼泽软泥怪
                new AnduinLothar(),//安度因洛萨
                new SilverHandRecruit(),//白银之手新兵
                new BluegillWarrior(),//蓝腮战士
                new MurlocWarleader(),//鱼人领军
                new OldMurkEye(),//老瞎眼
                new AnyfinCanHappen(),//亡者归来
                new Consecration(),//奉献
                new Equality(),//生而平等
                new LayOnHands(),//圣疗
                new TruesilverChampion(),//真银圣剑
                new SludgeBelcher(),//淤泥喷射者
                new Slime()//淤泥怪
            };

        public CardsUtil()
        {
            AllCard.ForEach(c => c.CardCode = c.GetType().Name);
        }

        public List<Card> GetSharpswordOilCards()
        {
            return new List<Card>()
            {
                new Rogue(),
                new DeadlyPoison(),
                new DeadlyPoison(),
                new BladeFlurry(),
                new BladeFlurry(),
                new LootHoarder(),
                new TombPillager(),
                new Tinker_sSharpswordOil(),
                new Tinker_sSharpswordOil(),
                new PilotedShredder(),
                new PilotedShredder(),
                new Loatheb(),
                new AntiqueHealbot(),
                new Assassin_sBlade(),                
                new EdwinVanCleef(),
                new SI7Agent(),
                new SI7Agent(),
                new BloodmageThalnos(),
                new Sap(),
                new Sap(),                
                new Eviscerate(),
                new Eviscerate(),
                new AzureDrake(),
                new AzureDrake(),
                new Preparation(),
                new Preparation(),
                new Sprint(),
                new Backstab(),
                new Backstab(),
                new FanofKnives(),
                new FanofKnives(),
            };
        }

        public List<Card> GetZooCards()
        {
            return new List<Card>()
            {
                new Warlock(),
                new DefenderOfArgus(),
                new DefenderOfArgus(),
                new FlameImp(),
                new FlameImp(),
                new Doomguard(),
                new Doomguard(),
                new DireWolfAlpha(),
                new DireWolfAlpha(),
                new NerubianEgg(),
                new NerubianEgg(),
                new PowerOverwhelming(),
                new PowerOverwhelming(),
                new ImpGangBoss(),
                new ImpGangBoss(),
                new Implosion(),
                new Implosion(),
                new PilotedShredder(),
                new PilotedShredder(),
                new Voidwalker(),
                new Voidwalker(),
                new Loatheb(),
                new LeeroyJenkins(),
                new KnifeJuggler(),
                new KnifeJuggler(),
                new AcidicSwampOoze(),
                new JiaoXiaoDeZhongShi(),
                new JiaoXiaoDeZhongShi(),
                new GuiLingZhiZhu(),
                new GuiLingZhiZhu(),
                new MadBomber(),
            };
        }
    }
}
