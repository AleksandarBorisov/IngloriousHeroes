using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Diagnostics;

namespace IngloriousHeros.Core.Game.Interfaces
{
    public interface IWorld
    {
        IList<IHero> Heroes { get; }

        IList<IItem> Items { get; }

        IList<ISpecialSkills> RobotSkills { get; }


        void InitializeEnvironment();

        void CreateWorld();

        Process StartSoundPlayer();
    }
}
