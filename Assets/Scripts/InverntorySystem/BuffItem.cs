using UnityEngine;

public class BuffItem : Item
{
    public override void Use()
    {
        Debug.Log("Player has been use " + GetItemName());
    }


}
