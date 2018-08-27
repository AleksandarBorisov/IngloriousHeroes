using IngloriousHeros.Core.UI;
using IngloriousHeros.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace IngloriousHeros.Tests.MessageBufferTests
{
    [TestClass]
    public class MessageBuffer_Should
    {
        [TestMethod]
        public void DequeueElements_WhenCountIsAboveTwenty()
        {
            // Arrange
            var mockConsole = new Mock<IConsole>();
            var sut = new MessageBuffer(mockConsole.Object);

            // Act
            for (int i = 0; i < 1000000; i++)
            {
                sut.Enqueue($"Message #{i}");
            }

            Assert.AreEqual(20, sut.Count);
        }

        [TestMethod]
        public void LockItself_WhileItIsBeingUsedByAThread()
        {
            // Tests if the MessageBuffer is thread-safe

            // Arrange
            var mockConsole = new Mock<IConsole>();
            var sut = new MessageBuffer(mockConsole.Object);

            // Act
            var threadOne = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    sut.Enqueue("Thread one.");
                }
            });

            var threadTwo = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    sut.Enqueue("Thread two.");
                }
            });

            threadOne.Start();
            threadTwo.Start();

            threadOne.Join();
            threadTwo.Join();

            // Assert
            Assert.AreEqual(20, sut.Count);
        }

        [TestMethod]
        public void RemoveAllElements_WhenMethodClearIsCalled()
        {
            // Arrange
            var mockConsole = new Mock<IConsole>();
            var sut = new MessageBuffer(mockConsole.Object);

            for (int i = 0; i < 1000000; i++)
            {
                sut.Enqueue($"Element #{i}");
            }

            // Act
            sut.Clear();

            // Assert
            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        public void ThrowAnException_WhenDequeuingAnEmptyMessageBuffer()
        {
            // Arrange
            var mockConsole = new Mock<IConsole>();
            var sut = new MessageBuffer(mockConsole.Object);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => sut.Dequeue());
        }

        [TestMethod]
        public void CallWriteMethodOnGameConsole_WhenPrintMethodInvoked()
        {
            // Arrange
            var mockConsole = new Mock<IConsole>();
            var sut = new MessageBuffer(mockConsole.Object);

            sut.Enqueue("test");

            mockConsole
                .Setup(m => m.Write(It.IsAny<string>()));

            // Act
            sut.PrintBuffer();

            // Assert
            mockConsole.Verify(m => m.Write(It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
