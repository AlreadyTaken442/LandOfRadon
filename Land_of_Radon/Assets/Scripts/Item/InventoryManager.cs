using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

   public int selectedSlot = -1;
    private PlayerHand playerHand;

    private void Start()
    {
        ChangeSelectedSlot(0);
        playerHand = GameObject.FindGameObjectWithTag("Hand").GetComponent<PlayerHand>();
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
    
        if (selectedSlot >= 0) {
            playerHand.EmptyHand();
        inventorySlots[selectedSlot].Deselect(); 
    }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
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
                return;
            }
        }
    }

    public void AddItem(Item item)
    {
        AddToEmptySlot(item);
    }

   
}