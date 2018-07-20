using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleForAzeroth.UnitTest.Servant.Neutral.Classical
{
    [TestClass]
    public class AcolyteOfPainTest : BaseGameTest
    {        
        public AcolyteOfPainTest()
        {
            InitGameContext();
        }

        [Fact]
        [TestMethod]
        
        public void WhenInHand()
        {
            var context = gameContext;
            //Assert.True(true);
        }
    }
}
