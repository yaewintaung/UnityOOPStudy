using System.Collections.Generic;
using UnityEngine;

public class InverntorySystem : MonoBehaviour
{
    public List<Item> items;

    public void AddItem(Item item)
    {
        items.Add(item); 
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void UseItem(Item item)
    {
        item.Use();
    }

    public List<Item> GetItems()
    {
        return items; 
    }
}
