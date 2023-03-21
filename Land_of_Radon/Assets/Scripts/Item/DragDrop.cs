using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//Interfaces
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image image;
    public static GameObject itemBeingDragged;
    private GameObject canvas;
    
  [HideInInspector] public Transform parentAfterDrag;

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
    }


    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }


    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        Debug.Log("Test");
       
    }

    
}
 


    
