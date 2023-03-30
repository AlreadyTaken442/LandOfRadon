using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// DragDrop-Klasse implementiert die Interfaces IBeginDragHandler, IDragHandler, IEndDragHandler,
// um das Ziehen und Ablegen von Gegenständen im Inventar zu ermöglichen.
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Private Variablen
    private GameObject canvas;          // Die Haupt-Canvas des Spiels.
    private PlayerHand playerHand;      // Referenz auf das PlayerHand-Skript, das den Inventarplatz darstellt.
    private InventoryItem inventoryItem;// Referenz auf das InventoryItem-Skript, das das Inventar des Spielers verwaltet.

    // Öffentliche Variablen
    public Image image;                // Das Image-Objekt des Gegenstands.
    public static GameObject itemBeingDragged; // Das aktuell gezogene Gegenstandsobjekt.

    // Versteckte Variable
    [HideInInspector] public Transform parentAfterDrag; // Der Eltern-Transform des Gegenstands, nachdem er gezogen wurde.

    // Diese Methode wird aufgerufen, wenn das Skript aktiv wird.
    private void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("Hand").GetComponent<PlayerHand>();
        inventoryItem = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryItem>();
    }

    // Diese Methode wird aufgerufen, bevor das Skript aktiv wird.
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Diese Methode wird aufgerufen, wenn das Ziehen eines Gegenstands beginnt.
    public void OnBeginDrag(PointerEventData eventData)
    {
        inventoryItem.isFull[GetComponentInParent<InventorySlot>().i] = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        Debug.Log("Begin Drag");
    }

    // Diese Methode wird aufgerufen, während ein Gegenstand gezogen wird.
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        Debug.Log("Dragging");
    }

    // Diese Methode wird aufgerufen, wenn ein Gegenstand abgelegt wird.
    public void OnEndDrag(PointerEventData eventData)
    {
        playerHand.EmptyHand();
        transform.SetParent(parentAfterDrag);
        inventoryItem.isFull[GetComponentInParent<InventorySlot>().i] = true;
        image.raycastTarget = true;
        Debug.Log("End Dragging");
    }
}
