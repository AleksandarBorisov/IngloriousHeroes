using Autofac;
using Autofac.Core;
using System;

namespace IngloriousHeros.Core.UI.DrawCaption.Factory
{
    public class DrawCaptionFactory : IDrawCaptionFactory
    {
        private IComponentContext autofacContext;

        public DrawCaptionFactory(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public IDrawCaption GetCommand(string commandName)
        {
            try
            {
                return autofacContext.ResolveNamed<IDrawCaption>(commandName);
            }
            catch(DependencyResolutionException ex)
            {
                throw new ArgumentException("No such command implemented! Consider implementing it before using!", ex);
            }
        }

    }
}
