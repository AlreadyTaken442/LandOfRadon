using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerfolgungNoDash : MonoBehaviour
{
    // Eine Referenz auf das Transform-Objekt des Hackers.
    public Transform hackerObjekt;

    // Der Radius, in dem der Enemy den Hacker verfolgen soll.
    public float verfolgungsRadius = 5f;

    // Die Geschwindigkeit, mit der sich der Enemy bewegen soll.
    public float geschwindigkeit = 3f;

    // Eine Referenz auf das Rigidbody2D-Objekt des Enemies.
    private Rigidbody2D rb;

    void Start()
    {
        // Erhalte die Rigidbody2D-Komponente, die an das GameObject angehängt ist, auf dem dieses Skript ausgeführt wird.
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Berechne die Distanz zwischen dem Enemy und dem Hacker.
        float distanzZumHacker = Vector2.Distance(transform.position, hackerObjekt.position);

        // Überprüfe, ob der Hacker sich innerhalb des Verfolgungsradius befindet.
        if (distanzZumHacker <= verfolgungsRadius)
        {
            // Berechne die Richtung, in die der Enemy sich bewegen soll, um den Hacker zu verfolgen.
            Vector2 richtungZumHacker = (hackerObjekt.position - transform.position).normalized;

            // Bewege den Enemy in Richtung des Hackers mit einer bestimmten Geschwindigkeit.
            rb.velocity = richtungZumHacker * geschwindigkeit;
        }
        else
        {
            // Setze die Geschwindigkeit des Enemies auf Null, wenn sich der Hacker außerhalb des Verfolgungsradius befindet.
            rb.velocity = Vector2.zero;
        }
    }
}
