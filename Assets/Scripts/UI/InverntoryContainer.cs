using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InverntoryContainer : MonoBehaviour
{

    public event EventHandler<OnSelectedSlotChangeEventArg> OnSelectedSlotChanged;
    public class OnSelectedSlotChangeEventArg
    {
        public Item slot;
    }

    [SerializeField] private InverntorySystem inventorySystem;

    [SerializeField] private List<ItemSlot> itemSlots;

    Item selectedItem;


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
                    OnSelectedSlotChanged?.Invoke(this, new OnSelectedSlotChangeEventArg
                    {
                        slot = item
                    });
                });

                slotIndex++;
            }
        }
    }


}
