namespace IngloriousHeros.Models.Contracts
{
    public interface IWeapon : IItem
    {
        int BonusDamage { get; set; }
    }
}
