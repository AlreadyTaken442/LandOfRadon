using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private InventoryItem inventory;
    public GameObject itemButton;
    public int cashValue = 1;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryItem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }

            }


            // Money System
            playermoneyinventory moneyinventory = other.GetComponent<playermoneyinventory>();

            if (moneyinventory != null)
            {
                // Geldbetrag des Spielers wird festgelegt
                moneyinventory.money = moneyinventory.Money + cashValue;

                // In der Console wird ausgegeben wie viel Money der Spieler hat
                print("Player has" + moneyinventory.Money + "money in it.");
                gameObject.SetActive(false);
            }
        }
    }

                                                                                                                               
}
