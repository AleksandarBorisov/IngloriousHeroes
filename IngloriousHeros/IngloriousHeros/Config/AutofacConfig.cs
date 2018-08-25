using Autofac;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Core.UI.Models;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Heros;
using System;
using System.Reflection;

namespace IngloriousHeros.Config
{
    public class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // 
            builder.RegisterType<Draw>().As<IDraw>().SingleInstance();
            builder.RegisterType<MainScreen>().As<IMainScreen>().SingleInstance();
            RegisterCoreComponents(builder);
            RegisterHeroTypes(builder);
            RegisterTypes(builder);

            return builder.Build();
        }

        private static void RegisterCoreComponents(ContainerBuilder builder)
        {
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

        private static void RegisterTypes(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
        }
    }
}
