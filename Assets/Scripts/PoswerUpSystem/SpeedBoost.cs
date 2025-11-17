using UnityEngine;

public class SpeedBoost : IPowerUp
{
    private float boostSpeed = 10f;

    public void Apply(Player player)
    {
        Debug.Log("Player Applied Speed Boost");
        player.SetSpeed(boostSpeed);
    }

    public void Remove(Player player)
    {
        Debug.Log("Player Removed Speed Boost");
        player.SetSpeed(player.GetSpeed());

    }
}
