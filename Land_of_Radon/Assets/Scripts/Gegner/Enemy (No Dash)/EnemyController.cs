using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Eine Referenz auf das KnockbackFeedback-Script.
    private KnockbackFeedback knockback;

    private void Start()
    {
        // Erhalte die KnockbackFeedback-Komponente, die an das GameObject angeh�ngt ist, auf dem dieses Skript ausgef�hrt wird.
        knockback = GetComponent<KnockbackFeedback>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �berpr�fe, ob der andere Teilnehmer des Zusammensto�es mit dem Enemy-GameObject ein Spieler-GameObject ist.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Berechne die Richtung, in die der Spieler zur�ckgesto�en werden soll, basierend auf der Position des Spielers und des Enemies.
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            // Wende das Knockback auf den Spieler an.
            knockback.ApplyKnockback(direction);
        }
    }
}
