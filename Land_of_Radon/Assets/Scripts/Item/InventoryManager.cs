using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
            }

        }
    }
    void ChangeSelectedSlot(int newValue) { 
    {
        if (selectedSlot >= 0) { }
        inventorySlots[selectedSlot].Deselect();
    }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    void CheckAndAddToExistingStack(Item item)
    {
        // Überprüfen, ob ein Slot das gleiche Element mit einer Anzahl kleiner als das Maximum enthält
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DragDrop itemInSlot = slot.GetComponentInChildren<DragDrop>();
            if (itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return;
            }
        }
    }

    void AddToEmptySlot(Item item)
    {
        // Suchen nach einem leeren Slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DragDrop itemInSlot = slot.GetComponentInChildren<DragDrop>();
            if (itemInSlot == null || itemInSlot.gameObject == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    public void AddItem(Item item)
    {
        CheckAndAddToExistingStack(item);
        AddToEmptySlot(item);
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DragDrop inventoryItem = newItemGo.GetComponent<DragDrop>();
        inventoryItem.InitaliseItem(item);
    }
}