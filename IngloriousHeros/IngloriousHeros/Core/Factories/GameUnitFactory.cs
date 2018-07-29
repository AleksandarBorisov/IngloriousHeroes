using IngloriousHeros.Models.Armours;
using IngloriousHeros.Models.Heros;
using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Items;
using IngloriousHeros.Models.Weapons;

namespace IngloriousHeros.Core.Factories
{
    public class GameUnitFactory : IGameUnitFactory
    {

        //TODO: Implement GameUnit class
        public IHero CreateArcher()
        {
            return new Archer();
        }

        public IHero CreateBrute()
        {
            return new Brute();
        }

        public IHero CreateGnome()
        {
            return new Gnome();
        }


        public IHero CreateJedi()
        {
            return new Jedi();
        }

        public IHero CreateWarrior()
        {
            return new Warrior();
        }

        public IHero CreateWizzard()
        {
            return new Wizzard();
        }

        public IItem CreateHelmet()
        {
            return new Helmet();
        }

        public IItem CreateAmmo()
        {
            return new Ammo();
        }

        public IItem CreateLaser()
        {
            return new Laser();
        }

        public IItem CreateMetal()
        {
            return new Metal();
        }

        public IItem CreatePlatemail()
        {
            return new Platemail();
        }

        public IItem CreatePotion()
        {
            return new Potion();
        }

        public IItem CreateRing()
        {
            return new Ring();
        }

        public IItem CreateShield()
        {
            return new Shield();
        }

        public IItem CreateSpear()
        {
            return new Spear();
        }

        public IItem CreateStaff()
        {
            return new Staff();
        }

        public IItem CreateSword()
        {
            return new Sword();
        }


        
    }
}
