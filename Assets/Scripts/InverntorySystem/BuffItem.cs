using UnityEngine;

public class BuffItem : Item
{
    public override void Use(InverntorySystem inverntorySystem)
    {
        Debug.Log("Player has been use " + GetItemName());
    }


}
