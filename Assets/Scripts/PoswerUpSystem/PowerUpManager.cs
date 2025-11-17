using System;
using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public void PlayerPowerUp(IPowerUp powerUp,Player player)
    {
        powerUp.Apply(player);
        StartCoroutine(PowerStart(powerUp, player));
    }

    IEnumerator PowerStart(IPowerUp powerUp, Player player)
    {
        yield return new WaitForSeconds(5);
        RemovePower(powerUp, player);
    }

    private void RemovePower(IPowerUp powerUp, Player player)
    {
        powerUp.Remove(player);
    }
}
