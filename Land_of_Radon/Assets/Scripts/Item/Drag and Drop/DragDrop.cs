using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//Interfaces
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //Private
    private GameObject canvas;
    private PlayerHand playerHand;
    private InventoryItem inventoryItem;
    //Public
    public Image image;
    public static GameObject itemBeingDragged;
    
    // HideInInspector
    [HideInInspector] public Transform parentAfterDrag;
 


    //voids
    private void Start()
    {
        //  InitaliseItem(item);
        playerHand = GameObject.FindGameObjectWithTag("Hand").GetComponent<PlayerHand>();
        inventoryItem = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryItem>();
    }

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        // GetComponentInParent<InventorySlot>
        inventoryItem.isFull[GetComponentInParent<InventorySlot>().i] = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        Debug.Log("Dragging");

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        playerHand.EmptyHand();
        transform.SetParent(parentAfterDrag);
        inventoryItem.isFull[GetComponentInParent<InventorySlot>().i] = true;
        image.raycastTarget = true;
        Debug.Log("End Dragging");
    }


   

    
}
 


    
