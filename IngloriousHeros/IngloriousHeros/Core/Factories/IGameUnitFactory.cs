using IngloriousHeros.Contracts;

namespace IngloriousHeros.Core.Factories
{
    public interface IGameUnitFactory
    {
        IItem CreateHelmet();

        IItem CreatePlatemail();

        IItem CreateRing();

        IItem CreateShield();

        IItem CreateAmmo();

        IItem CreateMetal();

        IItem CreatePotion();

        IItem CreateLaser();

        IItem CreateSpear();

        IItem CreateStaff();

        IItem CreateSword();

        IHero CreateArcher();

        IHero CreateBrute();

        IHero CreateGnome();

        IHero CreateJedi();

        IHero CreateWarrior();

        IHero CreateWizzard();
        //TODO: Implement IGameFactory interface
    }
}
