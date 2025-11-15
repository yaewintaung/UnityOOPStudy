using UnityEngine;

public class HealthPotion : MonoBehaviour, IInteractable, IHealable
{
    [SerializeField] private int healthAmount = 3;

    public int GetHealAmount()
    {
        return healthAmount;
    }



    public void Interact()
    {
        Destroy(gameObject);
    }
}
