using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verfolgung : MonoBehaviour
{
    public Transform hackerObjekt;
    public float verfolgungsRadius = 5f;
    public float geschwindigkeit = 3f;
    private Rigidbody2D rb;

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
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
