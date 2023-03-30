using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    // Start is called before the first frame update
    // Wird einmal aufgerufen, bevor die erste Bildrate berechnet wird
    void Start()
    {
        // Berechnung der Bildschirmgrenzen in Weltkoordinaten
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Wird einmal pro Bildrate aufgerufen, nachdem alle Update-Methoden ausgeführt wurden
    void LateUpdate()
    {
        // Position des Objekts wird gespeichert
        Vector3 viewPos = transform.position;

        // Position des Objekts wird innerhalb der Grenzen des Bildschirms gehalten
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);

        // Die neue Position wird dem Objekt zugewiesen
        transform.position = viewPos;
    }
}
