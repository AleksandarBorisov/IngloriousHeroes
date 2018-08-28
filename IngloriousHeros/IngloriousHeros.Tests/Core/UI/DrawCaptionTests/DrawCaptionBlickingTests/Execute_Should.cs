using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using IngloriousHeros.Core.UI.DrawCaption;
using IngloriousHeros.Core.Utilities;
using IngloriousHeros.Core.UI.DrawCaption.Providers;

namespace IngloriousHeros.Tests.Core.UI.DrawCaptionTests.DrawCaptionBlickingTests
{
    [TestClass]
    public class Execute_Should
    {

        [TestMethod]
        [Ignore]
        public void CallGameConsole_WhenParametersAreValid()
        {//Test enters an endless while-loop
            var listOfValidParams = new List<string>() { "0", "20", "choose hero", "FontSolidLetters", "200" };
            var processLetterMock = new Mock<IProcessLetter>();
            processLetterMock
                .Setup(processor => processor.Execute(It.IsAny<char>(), It.IsAny<string>()))
                .Returns(new char[,] { { 'a' }, { 'b' } });
            var gameConsoleMock = new Mock<IConsole>();

            var captionBlinkingMock = new DrawCaptionBlinking(processLetterMock.Object, gameConsoleMock.Object);

            captionBlinkingMock.Execute(listOfValidParams);

            gameConsoleMock.Verify(gameConsole => gameConsole.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
