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
    public class AtackDelay_Should
    {
        private Location locationMock;
        private string heroMockName;
        private sbyte heroMockHealth;
        private double heroMockDamage;
        private int heroMockAtackDelay;
        private List<IItem> heroMockItems;
        private Mock<Hero> heroMock;
        private int heroMockInvalidAtackDelay = -15;

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


            //Act
            heroMock =
                new Mock<Hero>(heroMockName, heroMockHealth, heroMockDamage,
                heroMockAtackDelay, locationMock, heroMockItems);
            heroMock.CallBase = true;
        }

        [TestMethod]
        public void NotThrowException_WhenPassedValuesAreValid()
        {
            //Assert
            Assert.AreEqual(heroMockAtackDelay, heroMock.Object.AttackDelay, "Incorrect AtackDelay");
        }

        [TestMethod]
        public void ThrowArgumentException_WhenPassedValueIsinvalid()
        {
            Assert.ThrowsException<ArgumentException>(() => heroMock.Object.AttackDelay = heroMockInvalidAtackDelay);
        }
    }
}
