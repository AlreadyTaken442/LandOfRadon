using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;

    private void Start()
    {
        // Slots für Waffen sind die ersten drei
        for (int i = 0; i < 3; i++)
        {
            slots[i].GetComponent<Slot>().allowedTag = "Weapon";
        }
        // Slots für andere Gegenstände sind die restlichen vier
        for (int i = 3; i < slots.Length; i++)
        {
            slots[i].GetComponent<Slot>().allowedTag = "Item";
        }
    }
}

public class Slot : MonoBehaviour, IDropHandler
{
    public string allowedTag;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        if (droppedItem != null && droppedItem.CompareTag(allowedTag))
        {
            droppedItem.transform.SetParent(transform);
        }
    }
}
