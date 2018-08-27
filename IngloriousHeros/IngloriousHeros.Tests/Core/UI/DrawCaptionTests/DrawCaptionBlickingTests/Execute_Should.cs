using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using IngloriousHeros.Core.UI.DrawCaption;
using IngloriousHeros.Core.Utilities;

namespace IngloriousHeros.Tests.Core.UI.DrawCaptionTests.DrawCaptionBlickingTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallGameConsole_WhenParametersAreValid()
        {
            var listOfValidParams = new List<string>() { "0", "20", "choose hero", "FontSolidLetters", "200" };
            var autofacMock = new Mock<IComponentContext>();
            var gameConsoleMock = new Mock<IConsole>();

            var captionBlinkingMock = new DrawCaptionBlinking(autofacMock.Object,gameConsoleMock.Object);

            captionBlinkingMock.Execute(listOfValidParams);

            gameConsoleMock.Verify(gameConsole => gameConsole.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
