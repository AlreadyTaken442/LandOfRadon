using UnityEngine;

public class KnockbackFeedback : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;

    private Rigidbody2D rb;
    private bool isKnockback;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 direction)
    {
        if (!isKnockback)
        {
            isKnockback = true;
            rb.velocity = direction.normalized * knockbackForce;
            Invoke("StopKnockback", knockbackDuration);
        }
    }

    private void StopKnockback()
    {
        isKnockback = false;
        rb.velocity = Vector2.zero;
    }
}
