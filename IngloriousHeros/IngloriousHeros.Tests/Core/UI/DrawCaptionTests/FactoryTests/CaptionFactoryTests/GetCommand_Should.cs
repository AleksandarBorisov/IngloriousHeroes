using Autofac;
using IngloriousHeros.Core.UI.DrawCaption;
using IngloriousHeros.Core.UI.DrawCaption.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Tests.Core.UI.DrawCaptionTests.FactoryTests.CaptionFactoryTests
{
    [TestClass]
    public class GetCommand_Should
    {
        //[TestMethod]
        //public void ReturnTheCorrectCommand_WhenCalled()
        //{
        //    string commandName = "DrawCaptionBlinking";
        //    var commandMock = new Mock<IDrawCaption>();
        //    var autofacMock = new Mock<IComponentContext>();
        //    autofacMock
        //        .CallBase = true;
        //    autofacMock
        //        .Setup(autofac => autofac.ResolveNamed<IDrawCaption>(It.IsAny<string>()));

        //    var factory = new DrawCaptionFactory(autofacMock.Object);

        //    var command = factory.GetCommand(commandName);

        //    autofacMock.Verify(autofac => autofac.ResolveNamed<IDrawCaption>(It.IsAny<string>()), Times.Once);
        //}

        //[TestMethod]
        //public void ThrowArgumentException_WhenCommandIsNotValid()
        //{
        //    string commandName = "hghgh";
        //    var commandMock = new Mock<IDrawCaption>();
        //    var autofacMock = new Mock<IComponentContext>();
        //    autofacMock
        //        .CallBase = true;
        //    autofacMock
        //        .Setup(autofac => autofac.ResolveNamed<IDrawCaption>(It.IsAny<string>()));

        //    var factory = new DrawCaptionFactory(autofacMock.Object);

        //    var command = factory.GetCommand(commandName);

        //    autofacMock.Verify(autofac => autofac.ResolveNamed<IDrawCaption>(It.IsAny<string>()), Times.Once);
        //}
    }
}
