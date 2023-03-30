using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Charakter : MonoBehaviour // Definition der Charakter-Klasse
{
    public float speed; // Geschwindigkeit des Charakters
    [SerializeField] private InputActionReference movement; // Referenz auf eine InputAction, die die Bewegung des Charakters steuert
    private Rigidbody2D rigbod; // Rigidbody2D-Komponente des Charakters
    private Vector2 movementInput; // Eingabewerte für die Bewegung des Charakters

    public int maxHealth;
    public int currentHealth;
    private bool facingRight = true;
    public HealthBar healthBar;

    public Animator animator;

    public Transform target; // Ziel-Transform des Charakters (nicht verwendet)

    // Speichere die letzte Laufrichtung des Charakters
    private Vector2 lastDirection = Vector2.right;

    // Verweise auf das Sprite-Renderer-Komponente des Charakters
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigbod = GetComponent<Rigidbody2D>(); // Initialisierung des Rigidbody2D-Komponente
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>(); // Eingabewerte für die Bewegung lesen

        //if (currentHealth == 0)
        //{
        //    Destroy(gameObject);
        //    SceneManager.LoadScene("GameOver");
        //}

        // Bewege den Charakter in die ausgewählte Richtung
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        transform.Translate(direction * speed * Time.deltaTime);

        // Spiegle das Sprite, wenn sich die Laufrichtung ändert
        if (direction.x > 0 && !facingRight || direction.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (direction.x == 0 && direction.y == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("true");
            animator.SetTrigger("isFighting");
        }
        else
        {
            Debug.Log("Reset");
            animator.SetTrigger("isntFighting");
        }
    }

    private void FixedUpdate()
    {
        rigbod.velocity = movementInput * speed; // Bewegung des Charakters berechnen und an den Rigidbody übertragen
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
