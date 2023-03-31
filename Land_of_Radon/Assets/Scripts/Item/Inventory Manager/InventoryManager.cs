using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    // public int maxStackedItems = 4; // Die maximale Anzahl von gestapelten Items in einem Slot
    public InventorySlot[] inventorySlots; // Eine Liste von InventorySlot-Objekten
    // public GameObject inventoryItemPrefab; // Das Prefab f�r InventoryItem
    public int selectedSlot = -1; // Der aktuell ausgew�hlte Slot, -1 bedeutet, dass kein Slot ausgew�hlt ist
    private PlayerHand playerHand; // Eine Referenz auf das PlayerHand-Skript

    private void Start()
    {
        ChangeSelectedSlot(0); // Setze den ersten Slot als ausgew�hlt
        playerHand = GameObject.FindGameObjectWithTag("Hand").GetComponent<PlayerHand>(); // Hole das PlayerHand-Skript aus dem Hand-Objekt
    }

    private void Update()
    {
        if (Input.inputString != null) // Wenn eine Eingabe get�tigt wurde
        {
            bool isNumber = int.TryParse(Input.inputString, out int number); // �berpr�fe, ob es sich um eine Zahl handelt
            if (isNumber && number > 0 && number < 8) // Wenn es sich um eine Zahl zwischen 1 und 7 handelt
            {
                ChangeSelectedSlot(number - 1); // W�hle den entsprechenden Slot aus (Index beginnt bei 0)
            }

        }
    }

    // �ndert den aktuell ausgew�hlten Slot
    void ChangeSelectedSlot(int newValue)
    {

        if (selectedSlot >= 0)
        {
            playerHand.EmptyHand(); // Entferne das Item aus der Hand des Spielers
            inventorySlots[selectedSlot].Deselect(); // Deselektiere den vorher ausgew�hlten Slot
        }
        inventorySlots[newValue].Select(); // Selektiere den neuen Slot
        selectedSlot = newValue; // Setze den neuen Slot als aktuell ausgew�hlt
    }

    // F�gt ein Item zu einem leeren Slot hinzu
    void AddToEmptySlot(/*Item item */)
    {
        // Suche nach einem leeren Slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i]; // Hole den aktuellen InventorySlot
            DragDrop itemInSlot = slot.GetComponentInChildren<DragDrop>(); // �berpr�fe, ob es ein InventoryItem in dem Slot gibt
            if (itemInSlot == null || itemInSlot.gameObject == null) // Wenn kein InventoryItem gefunden wurde
            {
                return; // Beende die Funktion
            }
        }
    }

    // F�gt ein Item zum Inventar hinzu
    public void AddItem(/*Item item*/)
    {
        AddToEmptySlot(/*item */); // F�ge das Item zu einem leeren Slot hinzu
    }

}
