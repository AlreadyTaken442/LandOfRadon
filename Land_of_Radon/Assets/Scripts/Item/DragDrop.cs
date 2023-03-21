using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//Interfaces
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject itemBeingDragged;
    private GameObject canvas;
    Vector3 startPosition;
    Transform parentAfterDrag;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
       
        parentAfterDrag = transform.parent;

       transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
       
        Debug.Log(Input.mousePosition);
       transform.position = Input.mousePosition;
        Debug.Log("Test");
       


    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(parentAfterDrag);
       
    }
}
 


    
