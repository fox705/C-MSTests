using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    [TestCategory("Enemy Creation")]
    public class BossEnemyTest
    {
        [TestMethod]
        public void SpecialAttackValue()
        {
            var sut = new BossEnemy();

            Assert.AreEqual(166.6, sut.SpecialAttackPower, 0.07);


        }

    }
}