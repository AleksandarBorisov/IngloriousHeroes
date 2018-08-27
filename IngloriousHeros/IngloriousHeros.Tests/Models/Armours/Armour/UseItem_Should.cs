using IngloriousHeros.Models.Heros.Abstracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using IngloriousHeros.Models.Armours;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Common;

namespace IngloriousHeros.Tests.Models.Armours.Armour
{
    [TestClass]
    public class UseItem_Should
    {
        private int negativeBonusArmour = -10;



        [TestMethod]
        public void RemoveItemFromInventory_WhenBonusArmourIsNegative()
        {
            Location lockMock= new Location(0, 0);
            var itemMock = new Mock<IItem>();
            var armourMock = new Mock<IngloriousHeros.Models.Armours.Armour>(10);
            armourMock.CallBase = true;
            armourMock.Object.BonusArmour = negativeBonusArmour;
            var heroMock = new Mock<Hero>("name", (byte)25,50d,100,lockMock,new List<IItem>());
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
            Location lockMock = new Location(0, 0);
            var itemMock = new Mock<IItem>();
            var armourMock = new Mock<IngloriousHeros.Models.Armours.Armour>(10);
            armourMock.CallBase = true;
            armourMock.Object.BonusArmour = negativeBonusArmour;
            var heroMock = new Mock<Hero>("name", (byte)25, 50d, 100, lockMock, new List<IItem>());
            heroMock.CallBase = true;
            heroMock.Object.Inventory = new List<IItem>() { armourMock.Object };

            // Act 
            var result = armourMock.Object.UseItem(heroMock.Object);

            // Assert
            Assert.AreEqual(negativeBonusArmour, result, "Failed to return correct bonus armour");
        }
    }
}
