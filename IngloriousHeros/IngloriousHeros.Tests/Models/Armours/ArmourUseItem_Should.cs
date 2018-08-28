using IngloriousHeros.Models.Heros.Abstracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Armours;

namespace IngloriousHeros.Tests.Models.Armours
{
    [TestClass]
    public class ArmourUseItem_Should
    {
        private int negativeBonusArmour;
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
            negativeBonusArmour = -10;
            locationMock = new Location(0, 0);
            heroMockName = "TestHeroName";
            heroMockHealth = (sbyte)25;
            heroMockDamage = 50d;
            heroMockAtackDelay = 100;
            heroMockItems = new List<IItem>();
        }

        [TestMethod]
        public void RemoveItemFromInventory_WhenBonusArmourIsNegative()
        {
            // Arrange
            var itemMock = new Mock<IItem>();
            var armourMock = new Mock<Armour>(10);
            armourMock.CallBase = true;
            armourMock.Object.BonusArmour = negativeBonusArmour;
            var heroMock = 
                new Mock<Hero>(heroMockName,heroMockHealth,heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;
            heroMock.Object.Inventory = new List<IItem>() { armourMock.Object };

            // Act 
            armourMock.Object.UseItem(heroMock.Object);

            // Assert
            Assert.AreEqual(0, heroMock.Object.Inventory.Count, "Failed to remove Item");
        }

        [TestMethod]
        public void ReturnCorrectBonusArmour_WhenBonusArmourIsPositive()
        {
            // Arrange
            var itemMock = new Mock<IItem>();
            var armourMock = new Mock<Armour>(10);
            armourMock.CallBase = true;
            armourMock.Object.BonusArmour = negativeBonusArmour;
            var heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;
            heroMock.Object.Inventory = new List<IItem>() { armourMock.Object };

            // Act 
            var result = armourMock.Object.UseItem(heroMock.Object);

            // Assert
            Assert.AreEqual(negativeBonusArmour, result, "Failed to return correct bonus armour");
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInventoryIsEmpty()
        {
            // Arrange
            var itemMock = new Mock<IItem>();
            var weaponMock = new Mock<Armour>(10);
            weaponMock.CallBase = true;
            weaponMock.Object.BonusArmour = negativeBonusArmour;
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
