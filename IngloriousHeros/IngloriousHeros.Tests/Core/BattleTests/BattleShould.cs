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
            mockHero
                .SetupGet(h => h.Oponent)
                .Returns(mockOponent.Object);

            mockHero
                .Setup(h => h.Health);

            // Setup oponent
            mockOponent
                .SetupGet(o => o.Oponent)
                .Returns(mockHero.Object);

            mockOponent
                .Setup(o => o.Health)
                .Returns(100);

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
