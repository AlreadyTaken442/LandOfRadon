using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot : MonoBehaviour, IDropHandler
{     
    public void OnDrop(PointerEventData eventData)
    {

        // Ausgabe in der Console zum überprüfen
        Debug.Log("OnDrop");

        // Es wird getestet ob das "Item" getragen wird
        if (eventData.pointerDrag != null)
        {
            //Item wird fest gesetzt im Inventar-Slot"
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
