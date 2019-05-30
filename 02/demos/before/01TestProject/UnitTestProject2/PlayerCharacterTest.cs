using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnitTestProject2
{
    [TestClass]
    public class PlayerCharacterTest
    {
        private PlayerCharacter sut;
        private List<string> expectedWeapons;
        
        [TestInitialize]
        public void PlayerCharacterObject()
        {
            sut = new PlayerCharacter()
            {
                FirstName = "Sarah",
                LastName = "Smith",

            };

            expectedWeapons = new List<string>
            {
                
                "Long Bow",
                "Short Bow",
                "Short Sword"

            };

        }

        [TestMethod]
        [PlayerDeflaut]
        public void PlayerCharacterShould()
        {
            Console.WriteLine("Check if he is noob");
            Assert.IsTrue(sut.IsNoob);
        }
        [TestMethod]
        [PlayerDeflaut]
        public void PlayerNameByDefault()
        {
            Assert.IsNull(sut.Nickname);
        }

        [TestMethod]
        [PlayerHealth]
        public void StartWithDefaultHealty()
        {
            Assert.AreEqual(100, sut.Health);
        }

        [DataTestMethod]
        [CsvDataBase("Damage.csv")]
        [PlayerHealth]
        public void TakeDamage(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);
            Assert.AreEqual(expectedHealth, sut.Health);
        }


        [TestMethod]
        [PlayerHealth]
        public void TakeDamagaNotEqual()
        {
            sut.TakeDamage(30);
            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        [PlayerDeflaut]
        [TestCategory("Another Category")]
        public void IncreaseHealthAfterSleeping()
        {
            sut.Sleep();
            Assert.That.IsInRange(sut.Health,101,200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
            Assert.AreEqual("SArah Smith", sut.FullName, true);
        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            StringAssert.StartsWith(sut.FullName, sut.FirstName);
        }

        [TestMethod]
        public void HaveFullNameEndingWithFirstName()
        {
            StringAssert.EndsWith(sut.FullName, sut.LastName);
        }

        [TestMethod]
        public void NameContains()
        {
            StringAssert.Contains(sut.FullName, "ah Sm");
        }

        [TestMethod]
        public void CheckNameCorrectFormat()
        {
            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void ExpectedWeapons()
        {
            CollectionAssert.AreEqual(expectedWeapons,sut.Weapons);
        }
        [TestMethod]
        public void ExpectedWeaponsEcuivalent()
        {
            CollectionAssert.AreEquivalent(expectedWeapons, sut.Weapons);
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void CharacterHaveOneSword()
        {
            //Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
            CollectionAssert.That.OneItemSatisfy(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [TestMethod]
        public void HaveNoEmptyWeapons()
        {
            CollectionAssert.That.AllItemsSatisfy(sut.Weapons, 
                                                  weapon => !string.IsNullOrWhiteSpace(weapon));

            CollectionAssert.That.All(sut.Weapons, weapon =>
            {
                StringAssert.That.IsNullOrWhiteSpace(weapon);
                Assert.IsTrue(weapon.Length > 5); });

        }
    }
}
