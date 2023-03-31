using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Charakter : MonoBehaviour
{
    public float speed; // Die Geschwindigkeit des Charakters
    [SerializeField] private InputActionReference movement; // Eine Referenz auf eine InputAction, die die Bewegung des Charakters steuert
    private Rigidbody2D rigbod; // Die Rigidbody2D-Komponente des Charakters
    private Vector2 movementInput; // Die Eingabewerte für die Bewegung des Charakters
    public int maxHealth; // Die maximale Anzahl an Lebenspunkten des Charakters
    public int currentHealth; // Die aktuelle Anzahl an Lebenspunkten des Charakters
    private bool facingRight = true; // Eine Variable, die speichert, ob der Charakter nach rechts schaut
    public HealthBar healthBar; // Eine Referenz auf die HealthBar-Komponente
    public Animator animator; // Eine Referenz auf die Animator-Komponente
    public Transform target; // Das Ziel-Transform des Charakters (nicht verwendet)

    // Eine Variable, die die letzte Laufrichtung des Charakters speichert
    private Vector2 lastDirection = Vector2.right;

    // Eine Referenz auf die SpriteRenderer-Komponente des Charakters
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigbod = GetComponent<Rigidbody2D>(); // Initialisierung der Rigidbody2D-Komponente
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>(); // Initialisierung der SpriteRenderer-Komponente
    }

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>(); // Eingabewerte für die Bewegung lesen

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

        // Setze den Animator-Trigger isMoving, um zu signalisieren, dass der Charakter sich bewegt
        if (direction.x == 0 && direction.y == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        // Setze den Animator-Trigger isFighting, wenn die Leertaste gedrückt wird
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("true");
            animator.SetTrigger("isFighting");
        }
        else
        {
            
            animator.SetTrigger("isntFighting");
        }
    }

    private void FixedUpdate()
    {
        rigbod.velocity = movementInput * speed; // Bewegung des Charakters berechnen und an den Rigidbody übertragen
    }

    // Funktion zum Abziehen von Schaden vom Charakter
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0) {
            Die();
        }
    }

    // Funktion


    void Die()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}
