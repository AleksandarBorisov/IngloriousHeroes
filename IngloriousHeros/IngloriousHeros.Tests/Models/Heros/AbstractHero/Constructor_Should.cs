using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Heros.Abstracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Tests.Models.Heros.AbstractHero
{
    [TestClass]
    public class Constructor_Should
    {
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
            locationMock = new Location(0, 0);
            heroMockName = "TestHeroName";
            heroMockHealth = (sbyte)25;
            heroMockDamage = 50d;
            heroMockAtackDelay = 100;
            heroMockItems = new List<IItem>();
        }

        [TestMethod]
        public void CorrectlyAssignMembers_WhenValuesAreValid()
        {
            // Act
            var heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;

            // Assert
            Assert.AreEqual(heroMockName, heroMock.Object.Name,"Incorrect Name");
            Assert.AreEqual(heroMockHealth, heroMock.Object.Health,"Incorrect Health");
            Assert.AreEqual(heroMockDamage, heroMock.Object.Damage,"Incorrect Damage");
            Assert.AreEqual(heroMockAtackDelay, heroMock.Object.AttackDelay,"Incorrect AtackDelay");
        }

        [TestMethod]
        public void CorrectlyAssignCollections_WhenValuesAreValid()
        {
            // Act
            var heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;

            // Assert
            Assert.IsNotNull(heroMock.Object.Inventory,"Incorrect Inventory Items");
        }

        [TestMethod]
        public void CorrectlyAssignEnumerations_WhenValuesAreValid()
        {
            // Act
            var heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;

            // Assert
            Assert.IsNotNull(heroMock.Object.HbLocation, "Incorrect HealthBar Location");
        }
    }
}
