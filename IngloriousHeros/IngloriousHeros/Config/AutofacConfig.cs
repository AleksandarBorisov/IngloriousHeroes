using Autofac;
using IngloriousHeros.Core;
using IngloriousHeros.Core.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.Game.Interfaces;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Core.UI.DrawCaption;
using IngloriousHeros.Core.UI.DrawModel;
using IngloriousHeros.Core.UI.DrawModel.Factory;
using IngloriousHeros.Core.UI.Models;
using IngloriousHeros.Core.Utilities;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
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
            RegisterCoreComponents(builder);
            RegisterUIComponents(builder);

            builder.RegisterType<List<IHero>>().As<IList<IHero>>();
            builder.RegisterType<List<IItem>>().As<IList<IItem>>();
            builder.RegisterType<List<ISpecialItem>>().As<IList<ISpecialItem>>();
            
            //RegisterHeroTypes(builder);

            return builder.Build();
        }

        private static void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Draw>().As<IDraw>().SingleInstance();
            builder.RegisterType<MainScreen>().As<IMainScreen>().SingleInstance();
            //builder.RegisterType<World>().As<IWorld>().SingleInstance();
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

        private static void RegisterUIComponents(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var captionTypes = assembly.DefinedTypes
                .Where(typeInfo =>
                    typeInfo.ImplementedInterfaces.Contains(typeof(IDrawCaption)))
                .ToList();

            foreach (var caption in captionTypes)
            {
                builder.RegisterType(caption.AsType())
                .Named<IDrawCaption>(caption.Name.ToLower().Replace("draw", ""));
            }

            var captionFonts = assembly.DefinedTypes
                .Where(typeInfo =>
                    typeInfo.ImplementedInterfaces.Contains(typeof(IFont)))
                .ToList();

            foreach (var font in captionFonts)
            {
                builder.RegisterType(font.AsType())
                .Named<IFont>(font.Name.ToLower().Replace("font", ""));
            }

            var drawModelTypes = assembly.DefinedTypes
                .Where(typeInfo =>
                    typeInfo.ImplementedInterfaces.Contains(typeof(IDrawModel)))
                .ToList();

            foreach (var modelType in drawModelTypes)
            {
                builder.RegisterType(modelType.AsType())
                .Named<IDrawModel>(modelType.Name.ToLower().Replace("draw", ""));
            }

            var models = assembly.DefinedTypes
                .Where(typeInfo =>
                    typeInfo.ImplementedInterfaces.Contains(typeof(IModel)))
                .ToList();

            foreach (var model in models)
            {
                builder.RegisterType(model.AsType())
                .Named<IModel>(model.Name.ToLower().Replace("model", ""));
            }
        }
    }
}
