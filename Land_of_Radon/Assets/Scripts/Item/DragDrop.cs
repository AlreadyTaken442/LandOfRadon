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

    //Public
    public Text countText;
    public Image image;
    public static GameObject itemBeingDragged;
    
    // HideInInspector
  [HideInInspector] public Transform parentAfterDrag;
  [HideInInspector] public Item item;
  [HideInInspector] public int count = 1;


    //voids
    private void Start()
    {
        InitaliseItem(item);
        RefreshCount();
    }
  
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }


    public void InitaliseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
       transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        Debug.Log("Test");

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }


   

    
}
 


    
