using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
  public void AddItem(Item item)
    {
        // Finde einen leeren Slot
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            DragDrop itemInSlot = slot.GetComponentInChildren<DragDrop>();
        if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DragDrop inventoryItem = newItemGo.GetComponent<DragDrop>();
        inventoryItem.InitaliseItem(item);
    }
}
