using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Tests.Models.Weapons
{
    [TestClass]
    public class WeaponUseItem_Should
    {
        private int negativeBonusDamage;
        private Location locationMock;
        private string heroMockName;
        private sbyte heroMockHealth;
        private double heroMockDamage;
        private int heroMockAtackDelay;
        private List<IItem> heroMockItems;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            negativeBonusDamage = -10;
            locationMock = new Location(0, 0);
            heroMockName = "TestHeroName";
            heroMockHealth = (sbyte)25;
            heroMockDamage = 50d;
            heroMockAtackDelay = 100;
            heroMockItems = new List<IItem>();
        }

        [TestMethod]
        public void RemoveItemFromInventory_WhenBonusDamageIsNegative()
        {
            // Arrange
            var itemMock = new Mock<IItem>();
            var weaponMock = new Mock<Weapon>(10);
            weaponMock.CallBase = true;
            weaponMock.Object.BonusDamage = negativeBonusDamage;
            var heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;
            heroMock.Object.Inventory = new List<IItem>() { weaponMock.Object };

            // Act 
            weaponMock.Object.UseItem(heroMock.Object);

            // Assert
            Assert.AreEqual(0, heroMock.Object.Inventory.Count, "Failed to remove Item");
        }

        [TestMethod]
        public void ReturnCorrectBonusDamage_WhenBonusDamageIsPositive()
        {
            // Arrange
            var itemMock = new Mock<IItem>();
            var weaponMock = new Mock<Weapon>(10);
            weaponMock.CallBase = true;
            weaponMock.Object.BonusDamage = negativeBonusDamage;
            var heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;
            heroMock.Object.Inventory = new List<IItem>() { weaponMock.Object };

            // Act 
            var result = weaponMock.Object.UseItem(heroMock.Object);

            // Assert
            Assert.AreEqual(negativeBonusDamage, result, "Failed to return correct bonus armour");
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInventoryIsEmpty()
        {
            // Arrange
            var itemMock = new Mock<IItem>();
            var weaponMock = new Mock<Weapon>(10);
            weaponMock.CallBase = true;
            weaponMock.Object.BonusDamage = negativeBonusDamage;
            var heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;
            heroMock.Object.Inventory = new List<IItem>() { };

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => weaponMock.Object.UseItem(heroMock.Object));
        }
    }
}
