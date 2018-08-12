using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.SpecialSkills;

namespace IngloriousHeros.Models.Races
{
    public interface IRobot : IRace
    {
        void Transform(int wins);

        void BackToNormal();

        RobotSkills Transformation { get; }
    }
}
