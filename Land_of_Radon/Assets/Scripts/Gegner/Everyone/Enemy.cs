using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealthEnemy = 100; // Setzt die maximale Gesundheit des Feindes
    public int currentHealthEnemy; // Setzt die aktuelle Gesundheit des Feindes

    // Wird aufgerufen, bevor das erste Frame aktualisiert wird
    void Start()
    {
        currentHealthEnemy = maxHealthEnemy; // Setzt die aktuelle Gesundheit des Feindes auf das Maximum
    }

    // Diese Funktion wird aufgerufen, wenn der Feind Schaden nimmt
    public void TakeDamage(int damage)
    {
        currentHealthEnemy -= damage; // Verringert die aktuelle Gesundheit des Feindes um den Schaden

        if (currentHealthEnemy <= 0) // Wenn die aktuelle Gesundheit kleiner oder gleich 0 ist
        {
            
            Die(); // Ruft die Funktion Die() auf
        }
    }

    // Diese Funktion wird aufgerufen, wenn der Feind stirbt
    void Die()
    {
        Debug.Log("Enemy died!"); // Gibt eine Debug-Meldung aus, dass der Feind gestorben ist
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
        
    }
}
