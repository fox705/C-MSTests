using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class Lifecycle
    {
        static string SharedContext;

        [ClassInitialize]
        public static void LifecycleInicialize(TestContext context)
        {
            Console.WriteLine("...Lifecycle initialize");
        }

        [ClassCleanup]
        public static void LifecycleCleanup()
        {
            Console.WriteLine("...ClassCleanup Cleanup");
        }

        [TestInitialize]
        public void MethodInitialize()
        {
            Console.WriteLine("...Method Initialization");
        }


        [TestMethod]
        public void MethodA()
        {
            Console.WriteLine("...Method A ");
            Console.WriteLine("Database loading");
            

            SharedContext = "42";
        }

        [TestMethod]
        public void MethodB()
        {
            Console.WriteLine("...Method B ");
            Console.Write("DataBaseValue: " + SharedContext);
        }

        [TestCleanup]
        public void MethodCleanup()
        {
            Console.WriteLine("...Method Cleanup");
        }


        


    }
}