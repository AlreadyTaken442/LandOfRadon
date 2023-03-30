using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour
{
    [SerializeField] private GameObject item;



    // Private Variablen
    private PlayerHand playerHand; // Referenz auf das PlayerHand-Skript des Spielers
    private GameObject hand; // Referenz auf das Hand-Spielobjekt des Spielers
    private InventorySlot slot; // Referenz auf den übergeordneten Inventarslot
    private InventoryManager inventory; // Referenz auf das Inventar-Manager-Skript des Spielers
    private int i; // Der Index des Inventarslots

    private void Start()
    {
        // Zuweisung der Variablen
        hand = GameObject.FindGameObjectWithTag("Hand");
        playerHand = hand.GetComponent<PlayerHand>();
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        // Das Item wird in die Hand gesetzt, wenn der zugehörige Slot ausgewählt ist und die Hand leer ist
        PutInHand();
    }

    public void PutInHand()
    {
        slot = GetComponentInParent<InventorySlot>();
        i = slot.i;
        if (inventory.selectedSlot == i && playerHand.isFull == false)
        {
            playerHand.isFull = true;
            playerHand.inHand = Instantiate(item, hand.transform, false);
        }
    }

}
