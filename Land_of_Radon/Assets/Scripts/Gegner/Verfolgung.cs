using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verfolgung : MonoBehaviour
{
    public Transform hackerObjekt;
    public float verfolgungsRadius = 5f;
    public float geschwindigkeit = 3f;
    public float angriffsRadius = 1f; // der Radius, in dem der Feind angreift
    public float angriffsgeschwindigkeit = 2f; // die Geschwindigkeit, mit der der Feind angreift
    public int schaden = 10; // der Schaden, den der Feind verursacht
    private Rigidbody2D rb;
    private bool kannAngreifen = true; // eine Variable, die festlegt, ob der Feind angreifen kann

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float distanzZumHacker = Vector2.Distance(transform.position, hackerObjekt.position);
        if (distanzZumHacker <= verfolgungsRadius)
        {
            Vector2 richtungZumHacker = (hackerObjekt.position - transform.position).normalized;
            rb.velocity = richtungZumHacker * geschwindigkeit;

            // Angriff starten, wenn Spieler im Angriffsradius ist und der Feind bereit ist zu attackieren
            if (distanzZumHacker <= angriffsRadius && kannAngreifen)
            {
                StartCoroutine(Angriff());
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator Angriff()
    {
        kannAngreifen = false; // Der Feind kann nicht erneut angreifen, bis der Timer abgelaufen ist

        // Bewegung des Feindes stoppen
        rb.velocity = Vector2.zero;

        // Warte für die Angriffsverzögerung
        yield return new WaitForSeconds(angriffsgeschwindigkeit);

        // Schaden am Spieler anwenden
        if (hackerObjekt != null) // Überprüfen, ob der Spieler noch lebt
        {
            hackerObjekt.GetComponent<Charakter>().TakeDamage(schaden);
        }

        kannAngreifen = true; // Der Feind kann wieder angreifen
    }

}