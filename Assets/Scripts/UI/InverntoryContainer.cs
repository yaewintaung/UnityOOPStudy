using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InverntoryContainer : MonoBehaviour
{
    [SerializeField] private InverntorySystem inventorySystem;

    [SerializeField] private List<ItemSlot> itemSlots;


    private void Start()
    {
        UpdateInventoryUI();
    }


    public void UpdateInventoryUI()
    {
        var items = inventorySystem.GetItems();

        int slotIndex = 0;
        foreach (var item in items)
        {
            if(slotIndex < itemSlots.Count)
            {
                itemSlots[slotIndex].SetItem(item);
                itemSlots[slotIndex].ItemButton().onClick.AddListener(() =>
                {
                    inventorySystem.UseItem(item);
                    inventorySystem.RemoveItem(item);
                });
                slotIndex++;
            }
        }
    }


}
