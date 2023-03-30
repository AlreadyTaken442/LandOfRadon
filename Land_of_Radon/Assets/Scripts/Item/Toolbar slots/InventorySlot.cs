using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image; // Ein Bild, das den Slot visuell darstellt
    public Color SelctedColor, notSelectedColor; // Die Farben für den ausgewählten und nicht ausgewählten Slot
    public int i; // Die Index-Nummer des Slots im Inventar-Array

    private void Awake()
    {
        Deselect(); // Wird beim Start aufgerufen, um den Slot zu deselektieren
    }

    public void Select()
    {
        image.color = SelctedColor; // Ändert die Farbe des Bildes, um den ausgewählten Slot zu markieren
    }

    public void Deselect()
    {
        image.color = notSelectedColor; // Ändert die Farbe des Bildes, um den nicht ausgewählten Slot zu markieren
    }

    public void OnDrop(PointerEventData eventData) // Wird aufgerufen, wenn ein Gegenstand auf den Slot gezogen wird
    {
        if (transform.childCount == 0) // Prüft, ob der Slot leer ist
        {
            GameObject dropped = eventData.pointerDrag; // Der gezogene Gegenstand wird in einer Variablen gespeichert
            DragDrop draggableItem = dropped.GetComponent<DragDrop>(); // Das DragDrop-Skript des gezogenen Gegenstands wird abgerufen
            draggableItem.parentAfterDrag = transform; // Der neue Eltern-Transform des Gegenstands wird auf den Slot gesetzt
        }
    }
}
