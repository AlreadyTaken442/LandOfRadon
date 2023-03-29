using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour
{
    [SerializeField] private GameObject item;



    // Private
    private PlayerHand playerHand;
    private GameObject hand;
    private InventorySlot slot;
    private InventoryManager inventory;
    private int i;

    private void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        playerHand = hand.GetComponent<PlayerHand>();
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<InventoryManager>();

        
    }

    private void Update()
    {
        PutInHand();
    }

    public void PutInHand()
    {
        slot = GetComponentInParent<InventorySlot>();
        i = slot.i;
        if (inventory.selectedSlot == i  &&  playerHand.isFull == false)
      {
            playerHand.isFull = true;
            playerHand.inHand = Instantiate(item, hand.transform, false);
      }
    }
}
