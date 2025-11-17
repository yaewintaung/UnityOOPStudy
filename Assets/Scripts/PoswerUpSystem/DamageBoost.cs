using UnityEngine;

public class DamageBoost : IPowerUp
{
    public void Apply(Player player)
    {
        Debug.Log("Player Applied Damage Boost");

    }

    public void Remove(Player player)
    {
        Debug.Log("Player Remove Damage Boost");

    }


}
