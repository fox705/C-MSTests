using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class Assembly
    {
        [AssemblyInitialize]
        public static void AssemblyInt(TestContext context)
        {
            Console.WriteLine("Assembly Initialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("Assembly Initialize");
        }


    }
}