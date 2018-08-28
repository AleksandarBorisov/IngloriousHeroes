using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Heros;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Tests.Core.FactoryTests
{
    [TestClass]
    public class GameUnitFactory_Should
    {
        [TestMethod]
        public void ReturnAUnitOfTheRequestedType_WhenInvoked()
        {
            // Arrange & Act
            var sut = GameUnitFactory
                .CreateGameUnit<Wizzard>("Valid name", (sbyte)100, 5, 150, new Location(1, 1), new List<IItem>());

            // Assert
            Assert.AreEqual(typeof(Wizzard), sut.GetType());
        }

        [TestMethod]
        public void SetProperName_WhenCreatingInstance()
        {
            // Arrange & Act
            var sut = GameUnitFactory
                .CreateGameUnit<Wizzard>("Valid name", (sbyte)100, 5, 150, new Location(1, 1), new List<IItem>());

            // Assert
            Assert.AreEqual("Valid name", sut.Name);
        }

        [TestMethod]
        public void InitializeList_WhenCreatingInstance()
        {
            // Arrange & Act
            var sut = GameUnitFactory
                .CreateGameUnit<Wizzard>("Valid name", (sbyte)100, 5, 150, new Location(1, 1), new List<IItem>());

            // Assert
            Assert.IsNotNull(sut.Inventory);
        }

        [TestMethod]
        public void ShouldReturnANonNullInstance_WhenInvoked()
        {
            // Arrange & Act
            var sut = GameUnitFactory
                .CreateGameUnit<Wizzard>("Valid name", (sbyte)100, 5, 150, new Location(1, 1), new List<IItem>());

            // Assert
            Assert.IsNotNull(sut);
        }
    }
}
