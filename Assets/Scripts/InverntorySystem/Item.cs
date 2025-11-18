using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string itemName;

    public abstract void Use();

    public string GetItemName() => itemName;



}
