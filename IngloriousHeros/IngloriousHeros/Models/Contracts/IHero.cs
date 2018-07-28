using IngloriousHeros.Models.Common;

namespace IngloriousHeros.Models.Contracts
{
    public interface IHero : IExhaustible
    {
        Race HeroRace { get; }
        int Health { get; }
        int Armour { get; }
        int Damage { get; }
    }
}
