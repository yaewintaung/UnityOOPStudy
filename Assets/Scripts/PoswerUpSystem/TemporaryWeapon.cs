using UnityEngine;

public class TemporaryWeapon : IPowerUp
{
    Weapon weapon;

    public TemporaryWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public void Apply(Player player)
    {
        Debug.Log("Player Apply Tempory Weapon");
        player.EquipTemporyWeapon(weapon);
    }

    public void Remove(Player player)
    {
        Debug.Log("Player Removed Tempory Weapon");
        player.EquipTemporyWeapon(null);

    }
}
