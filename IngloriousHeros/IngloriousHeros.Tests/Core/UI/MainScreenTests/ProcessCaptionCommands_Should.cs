//using IngloriousHeros.Core.UI.DrawCaption;
//using IngloriousHeros.Core.UI.DrawCaption.Factory;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using IngloriousHeros.Core.UI;
//using IngloriousHeros.Core.UI.DrawModel.Factory;
//using Autofac;
//using IngloriousHeros.Core.Utilities;

//namespace IngloriousHeros.Tests.Core.UI.MainScreenTests
//{
//    [TestClass]
//    public class ProcessCaptionCommands_Should
//    {
//        private string commandMockName = "DrawCaptionBlinking";

//        [TestMethod]
//        public void CallCommandFromFactory_WhenInputListIsValid()
//        {
//            //IDrawModelFactory drawModelFactory,
//            //IComponentContext autofacContext,
//            //IConsole gameConsole

//            var modelFactoryMock = new Mock<IDrawModelFactory>();
//            var componentMock = new Mock<IComponentContext>();
//            var commandMock = new Mock<IDrawCaption>();
//            var gameConsoleMock = new Mock<IConsole>();
//            var captionFactoryMock = new Mock<IDrawCaptionFactory>();
//            captionFactoryMock
//                .Setup(factory => factory.GetCommand(commandMockName))
//                .Returns(commandMock.Object);

//            var mainScreen = new MainScreen(captionFactoryMock.Object,
//                modelFactoryMock.Object, componentMock.Object, gameConsoleMock.Object);
            
//            mainScreen.

//        }
//    }
//}
