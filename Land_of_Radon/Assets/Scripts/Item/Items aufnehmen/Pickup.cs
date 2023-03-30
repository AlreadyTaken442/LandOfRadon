using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private InventoryItem inventory; // Referenz auf das InventoryItem-Skript des Spielers
    public GameObject itemButton; // Prefab des Gegenstands im Inventar
    public int cashValue = 1; // Wert des Gegenstands in Geld

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryItem>(); // Spieler-Objekt wird gesucht und auf das InventoryItem-Skript zugegriffen
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Prüfen, ob das Kollisionsobjekt der Spieler ist
        {
            for (int i = 0; i < inventory.slots.Length; i++) // Schleife durch alle Slots des Inventars
            {
                if (inventory.isFull[i] == false) // Wenn der Slot noch nicht belegt ist
                {
                    inventory.isFull[i] = true; // Slot wird als belegt markiert
                    Instantiate(itemButton, inventory.slots[i].transform); // Prefab des Gegenstands wird instantiiert und im Inventarslot platziert
                    Destroy(gameObject); // Gegenstandsobjekt wird zerstört
                    break; // Schleife wird beendet
                }
            }

            // Geld System
            playermoneyinventory moneyinventory = other.GetComponent<playermoneyinventory>(); // Spieler-Objekt wird auf das playermoneyinventory-Skript überprüft

            if (moneyinventory != null) // Wenn der Spieler ein playermoneyinventory hat
            {
                moneyinventory.money = moneyinventory.Money + cashValue; // Der Geldbetrag des Spielers wird erhöht
                print("Player has" + moneyinventory.Money + "money in it."); // Ausgabe des Geldbetrags in der Konsole
                gameObject.SetActive(false); // Das Gegenstandsobjekt wird deaktiviert
            }
        }
    }
}
