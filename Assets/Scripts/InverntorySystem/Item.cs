using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string itemName;

    public abstract void Use(InverntorySystem inverntorySystem);

    public string GetItemName() => itemName;



}
