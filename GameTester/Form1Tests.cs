using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarmingGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmingGame.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void JustALoopTest()
        {
            int value = 10;
            for (int i = 0; i < value; i++)
            {
                if (i > 5)
                {
                    Assert.IsNotNull(i);
                }
            }
        }
    }
}