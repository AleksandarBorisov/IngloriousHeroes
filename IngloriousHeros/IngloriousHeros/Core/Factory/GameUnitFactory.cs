﻿using IngloriousHeros.Models.Contracts;
using System;

namespace IngloriousHeros.Core.Factories
{
    public static class GameUnitFactory
    {
        public static T CreateGameUnit<T>(params object[] parameters)
            where T : IExhaustible
        {
            return (T)Activator.CreateInstance(typeof(T), parameters);
        }
    }
}
