using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;

namespace GameEngine.Test
{
    [TestClass]
    public class PlayerCharacterTest
    {
        [TestMethod]
        public void BeInexperiencedWhenNew()
        {
            var sut = new PlayerCharacter();

        }
    }
}
