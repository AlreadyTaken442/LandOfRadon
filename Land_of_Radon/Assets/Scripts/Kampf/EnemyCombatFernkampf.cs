using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatFernkampf : MonoBehaviour
{
    public GameObject bulletPrefab;         // Prefab f�r Kugel
    public float bulletSpeed = 10f;         // Geschwindigkeit der Kugel
    public float shootDelay = 1f;           // Verz�gerung zwischen Sch�ssen
    public float bulletLifetime = 3f;       // Lebensdauer der Kugel
    public float shootingRange = 10f;       // Bereich, in dem das Objekt auf den Spieler schie�en kann
    public float bulletOffset = 1f;         // Abstand zwischen Objekt und Kugel-Startposition

    private GameObject player;              // Referenz auf Spielerobjekt
    private float lastShootTime;            // Zeit des letzten Schusses

    void Start()
    {
        // Spielerobjekt finden
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Distanz zum Spieler berechnen
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Nur schie�en, wenn der Spieler im Schussbereich ist und genug Zeit seit dem letzten Schuss vergangen ist
        if (distanceToPlayer <= shootingRange && Time.time - lastShootTime > shootDelay)
        {
            Shoot();                        // Schie�en
            lastShootTime = Time.time;      // Letzte Schusszeit aktualisieren
        }
    }

    void Shoot()
    {
        Vector2 bulletPosition = (Vector2)((Vector3)transform.position + (player.transform.position - (Vector3)transform.position).normalized * bulletOffset);
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        

        // Kugel nach Ablauf der Lebensdauer zerst�ren
        Destroy(bullet, bulletLifetime);
    }
}

