using UnityEngine;

public class ShieldPowerUp : IPowerUp
{
    private float shieldAmount = 3f;
    public void Apply(Player player)
    {
        Debug.Log("Shield PowerUp");
        player.SetShield(shieldAmount);
    }

    public void Remove(Player player)
    {
        Debug.Log("Shield PowerUp");
        player.SetShield(0);
    }
}
