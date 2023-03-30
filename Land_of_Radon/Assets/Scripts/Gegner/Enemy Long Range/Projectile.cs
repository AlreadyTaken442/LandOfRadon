using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed; // Geschwindigkeit des Projektils

    private Transform player;
    private Vector2 target; // Ziel des Projektils

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Spieler-Objekt finden

        target = new Vector2(player.position.x, player.position.y); // Ziel des Projektils auf die Position des Spielers setzen
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); // Projektil bewegen

        if (transform.position.x == target.x && transform.position.y == target.y) // Wenn das Projektil das Ziel erreicht hat
        {
            DestroyProjectile(); // Projektil zerstören
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Wenn das Projektil mit dem Spieler kollidiert
        {
            DestroyProjectile(); // Projektil zerstören
            other.GetComponent<Charakter>().TakeDamage(10); // Spieler Schaden zufügen
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject); // Projektil zerstören
    }
}
