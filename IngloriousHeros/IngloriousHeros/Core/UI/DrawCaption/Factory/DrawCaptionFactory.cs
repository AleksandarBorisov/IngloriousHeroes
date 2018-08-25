//using Autofac;
//using IngloriousHeros.Core.UI.DrawCaption.Interfaces;

//namespace IngloriousHeros.Core.UI.DrawCaption.Factory
//{
//    public class DrawCaptionFactory : IDrawCaptionFactory
//    {
//        private IComponentContext autofacContext;

//        public DrawCaptionFactory(IComponentContext autofacContext)
//        {
//            this.autofacContext = autofacContext;
//        }

//        public IDrawCaption GetCommand(string commandName)
//        {
//            return autofacContext.ResolveNamed<IDrawCaption>(commandName);
//        }

//    }
//}
