 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color SelctedColor, notSelectedColor;


    private void Awake()
    {
        Deselect();
    }
    public void Select()
    {
        image.color = notSelectedColor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DragDrop draggableItem = dropped.GetComponent<DragDrop>();
            draggableItem.parentAfterDrag = transform;
        }
    }
}