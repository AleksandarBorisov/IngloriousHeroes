using Autofac;
using IngloriousHeros.Core;
using IngloriousHeros.Core.UI.DrawCaption.Fonts;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Core.UI.DrawCaption;
using IngloriousHeros.Core.UI.DrawModel;
using IngloriousHeros.Core.UI.DrawModel.Models;
using IngloriousHeros.Core.Utilities;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IngloriousHeros.Core.Contracts;
using IngloriousHeros.Models.Heros;

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

            RegisterUIComponents(builder);
            RegisterCoreComponents(builder);
            RegisterHeroTypes(builder);

            return builder.Build();
        }

        private static void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<MainScreen>().As<IMainScreen>().SingleInstance();
            builder.RegisterType<GameEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<GameConsole>().As<IConsole>().SingleInstance();
            builder.RegisterType<MessageBuffer>().As<IMessageBuffer>().SingleInstance();
        }

        private static void RegisterHeroTypes(ContainerBuilder builder)
        {
            builder.RegisterType<Archer>().Named<IHero>(typeof(Archer).Name);
            builder.RegisterType<Brute>().Named<IHero>(typeof(Brute).Name);
            builder.RegisterType<Gnome>().Named<IHero>(typeof(Gnome).Name);
            builder.RegisterType<Jedi>().Named<IHero>(typeof(Jedi).Name);
            builder.RegisterType<Warrior>().Named<IHero>(typeof(Warrior).Name);
            builder.RegisterType<Wizzard>().Named<IHero>(typeof(Wizzard).Name);
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
                    .Named<IDrawCaption>(caption.Name.ToLower());
            }

            var captionFonts = assembly.DefinedTypes
                .Where(typeInfo =>
                    typeInfo.ImplementedInterfaces.Contains(typeof(IFont)))
                .ToList();

            foreach (var font in captionFonts)
            {
                builder.RegisterType(font.AsType())
                    .Named<IFont>(font.Name.ToLower());
            }

            var drawModelTypes = assembly.DefinedTypes
                .Where(typeInfo =>
                    typeInfo.ImplementedInterfaces.Contains(typeof(IDrawModel)))
                .ToList();

            foreach (var modelType in drawModelTypes)
            {
                builder.RegisterType(modelType.AsType())
                    .Named<IDrawModel>(modelType.Name.ToLower());
            }

            var models = assembly.DefinedTypes
                .Where(typeInfo =>
                    typeInfo.ImplementedInterfaces.Contains(typeof(IModel)))
                .ToList();

            foreach (var model in models)
            {
                builder.RegisterType(model.AsType())
                    .Named<IModel>(model.Name.ToLower());
            }
        }
    }
}