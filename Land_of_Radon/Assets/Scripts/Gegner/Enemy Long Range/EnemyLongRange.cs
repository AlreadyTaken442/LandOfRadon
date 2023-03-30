using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLongRange : MonoBehaviour
{
    public float speed; // Die Geschwindigkeit, mit der sich der Gegner bewegt.
    public float stoppingDistance; // Die Entfernung, bei der der Gegner stehen bleibt.
    public float retreatDistance; // Die Entfernung, bei der der Gegner zurückweicht.
    public float distancebetween; // Der Abstand, bei dem der Gegner den Spieler angreifen kann.
    private float distance; // Die tatsächliche Entfernung zwischen Gegner und Spieler.
    public GameObject projectille; // Das Projektil, das der Gegner abfeuert.
    private Transform player; // Der Transform-Objekt des Spielers.

    private float timeBtwShots; // Die Zeit, die zwischen Schüssen vergeht.
    public float startTimeBtwShots; // Der Startwert der Zeit zwischen Schüssen.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Finde den Spieler anhand des Tags "Player" und speichere seinen Transform-Objekt in der Variable "player".

        timeBtwShots = startTimeBtwShots; // Setze die Zeit zwischen Schüssen auf den Startwert.
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position); // Berechne die Entfernung zwischen Gegner und Spieler.

        // Wenn die Entfernung größer ist als die Stopping Distance, bewegt sich der Gegner auf den Spieler zu.
        if (distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        // Wenn der Gegner innerhalb der Stopping Distance, aber außerhalb der Retreat Distance ist, bleibt er stehen.
        else if (distance > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        // Wenn der Gegner innerhalb der Retreat Distance ist, weicht er zurück.
        else if (distance < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        // Wenn die Zeit zwischen den Schüssen abgelaufen ist und die Entfernung zum Spieler kleiner ist als die Attack Distanz, feuert der Gegner ein Projektil ab.
        if (timeBtwShots <= 0 && distance < distancebetween)
        {
            Instantiate(projectille, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots; // Setze die Zeit zwischen Schüssen auf den Startwert.
        }
        // Reduziere die Zeit zwischen den Schüssen.
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
