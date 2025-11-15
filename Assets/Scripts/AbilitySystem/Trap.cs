using UnityEngine;

public class Trap : MonoBehaviour, IDamageable, IInteractable
{
    [SerializeField] private int damage = 2;

    public int GetDamageAmount()
    {
        return damage;
    }

    public void Interact()
    {
        Destroy(gameObject);
    }
}
