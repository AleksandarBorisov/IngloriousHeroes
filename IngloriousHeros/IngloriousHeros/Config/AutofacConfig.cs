using Autofac;
using IngloriousHeros.Core;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Core.UI.Models;
using IngloriousHeros.Core.Utilities;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Reflection;

namespace IngloriousHeros.Config
{
    public class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // RegisterAssemblyComponents should be called first in order to register the default services
            RegisterAssemblyComponents(builder);

            builder.RegisterType<List<IHero>>().As<IList<IHero>>();
            builder.RegisterType<List<IItem>>().As<IList<IItem>>();
            builder.RegisterType<List<ISpecialItem>>().As<IList<ISpecialItem>>();
            
            RegisterCoreComponents(builder);
            RegisterHeroTypes(builder);

            return builder.Build();
        }

        private static void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Draw>().As<IDraw>().SingleInstance();
            builder.RegisterType<MainScreen>().As<IMainScreen>().SingleInstance();
            builder.RegisterType<GameEngine>().AsSelf();
            builder.RegisterType<GameConsole>().As<IConsole>().SingleInstance();
            builder.RegisterType<MessageBuffer>().As<IMessageBuffer>().SingleInstance();
        }

        private static void RegisterHeroTypes(ContainerBuilder builder)
        {
            //builder.RegisterType<Archer>().Named<IHero>(typeof(Archer).Name);
            //builder.RegisterType<Brute>().Named<IHero>(typeof(Brute).Name);
            //builder.RegisterType<Gnome>().Named<IHero>(typeof(Gnome).Name);
            //builder.RegisterType<Jedi>().Named<IHero>(typeof(Jedi).Name);
            //builder.RegisterType<Warrior>().Named<IHero>(typeof(Warrior).Name);
            //builder.RegisterType<Wizzard>().Named<IHero>(typeof(Wizzard).Name);
        }

        private static void RegisterAssemblyComponents(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
        }
    }
}
