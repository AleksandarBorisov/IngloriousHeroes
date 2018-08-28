using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.Utilities;
using IngloriousHeros.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IngloriousHeros.Tests.Core.BattleTests
{
    [TestClass]
    public class BattleShould
    {
        [TestMethod, Timeout(5000)]
        public void InvokeHeroAttackMethod_WhenBattleBegins()
        {
            // Arrange
            var mockHero = new Mock<IHero>();
            var mockOponent = new Mock<IHero>();
            var mockConsole = new Mock<IConsole>();

            // Setup hero
            mockHero.SetupProperty(h => h.Health);
            mockHero.SetupProperty(h => h.Damage);
            mockHero.SetupProperty(h => h.Oponent);
            mockHero.SetupProperty(h => h.AttackDelay);

            mockHero.Object.Health = 0;
            mockHero.Object.Damage = 10;
            mockHero.Object.Oponent = mockOponent.Object;
            mockHero.Object.AttackDelay = 250;

            // Setup oponent
            mockOponent.SetupProperty(h => h.Health);
            mockOponent.SetupProperty(h => h.Damage);
            mockOponent.SetupProperty(h => h.Oponent);
            mockOponent.SetupProperty(h => h.AttackDelay);

            mockOponent.Object.Health = 100;
            mockOponent.Object.Damage = 10;
            mockOponent.Object.Oponent = mockHero.Object;
            mockOponent.Object.AttackDelay = 350;

            var sut = new Battle(mockHero.Object, mockConsole.Object);

            // Act
            sut.Start();

            // Assert
            mockHero.Verify(h => h.Attack(), Times.AtLeastOnce);
        }

        [TestMethod, Timeout(10000)]
        public void InvokeHeroTakeMethod_WhenAttackMethodIsCalled()
        {
            // Arrange
            var mockHero = new Mock<IHero>();
            var mockOponent = new Mock<IHero>();
            var mockConsole = new Mock<IConsole>();

            // Setup hero
            mockHero
                .SetupGet(h => h.Oponent)
                .Returns(mockOponent.Object);

            mockHero
                .SetupGet(h => h.Health)
                .Returns(100);

            mockHero
                .SetupGet(h => h.Damage)
                .Returns(10);

            // Setup oponent
            mockOponent
                .SetupGet(o => o.Oponent)
                .Returns(mockHero.Object);

            mockOponent
                .SetupGet(o => o.Health)
                .Returns(100);

            mockOponent
                .SetupGet(o => o.Damage)
                .Returns(10);

            var sut = new Battle(mockHero.Object, mockConsole.Object);

            // Act
            sut.Start();

            // Assert
            mockHero.Verify(h => h.TakeDamage(It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}
