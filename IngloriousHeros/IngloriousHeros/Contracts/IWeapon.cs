namespace IngloriousHeros.Contracts
{
    public interface IWeapon : IItem
    {
        int BonusDamage { get; set; }

        int BonusAtackDelay { get; set; }
    }
}
