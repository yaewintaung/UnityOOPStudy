using UnityEngine;

public class HealthItem : Item
{
    public override void Use(InverntorySystem inverntorySystem)
    {
        Debug.Log("Health item has been used");
    }
}
