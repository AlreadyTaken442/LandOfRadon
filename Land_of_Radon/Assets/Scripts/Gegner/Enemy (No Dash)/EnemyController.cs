using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private KnockbackFeedback knockback;

    private void Start()
    {
        knockback = GetComponent<KnockbackFeedback>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            knockback.ApplyKnockback(direction);
        }
    }
}

