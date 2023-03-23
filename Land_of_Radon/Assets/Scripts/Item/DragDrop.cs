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
    public Image image;
    public static GameObject itemBeingDragged;
    
    // HideInInspector
  [HideInInspector] public Transform parentAfterDrag;
  // [HideInInspector] public Item item;


    //voids
    private void Start()
    {
      //  InitaliseItem(item);
        
    }
  
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
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

        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        Debug.Log("End Dragging");

    }


   

    
}
 


    
