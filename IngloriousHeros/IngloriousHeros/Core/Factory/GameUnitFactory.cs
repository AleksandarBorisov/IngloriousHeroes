﻿using IngloriousHeros.Models.Contracts;
using System;

namespace IngloriousHeros.Core.Factories
{
    public class GameUnitFactory
    {
        public static T CreateGameUnit<T>(params object[] parameters)
        {
            return (T)Activator.CreateInstance(typeof(T), parameters);
        }
    }
}
