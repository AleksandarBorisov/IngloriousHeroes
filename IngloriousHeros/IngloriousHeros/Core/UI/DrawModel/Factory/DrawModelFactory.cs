using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Core.UI.DrawModel.Factory
{
    class DrawModelFactory : IDrawModelFactory
    {
        private IComponentContext autofacContext;

        public DrawModelFactory(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public IDrawModel GetCommand(string commandName)
        {
            return autofacContext.ResolveNamed<IDrawModel>(commandName);
        }

    }
}
