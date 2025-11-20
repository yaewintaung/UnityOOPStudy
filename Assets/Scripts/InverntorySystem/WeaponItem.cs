using UnityEngine;

public class WeaponItem : Item
{
    [SerializeField] private Weapon weapon;
    
    public override void Use(InverntorySystem inverntorySystem)
    {
        GameManager.Instance.GetActivePlayer().SwitchWeapon(weapon);
        //Debug.Log("weapon has been used");
    }

    public Weapon GetWeapon()
    {
        return weapon; 
    }
}
