using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Charakter : MonoBehaviour // Definition der Charakter-Klasse
{
    public float speed; // Geschwindigkeit des Charakters
    [SerializeField] private InputActionReference movement; // Referenz auf eine InputAction, die die Bewegung des Charakters steuert
    private Rigidbody2D rigbod; // Rigidbody2D-Komponente des Charakters
    private Vector2 movementInput; // Eingabewerte für die Bewegung des Charakters

    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public Transform target; // Ziel-Transform des Charakters (nicht verwendet)

    public Animator animator;

    private void Start()
    {
        rigbod = GetComponent<Rigidbody2D>(); // Initialisierung des Rigidbody2D-Komponente
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //animator.SetFloat("speed");
        movementInput = movement.action.ReadValue<Vector2>(); // Eingabewerte für die Bewegung lesen

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
        }

        if(movementInput.x == 0 && movementInput.y == 0)
        {
            animator.SetBool("isRunning", false);
        } else
        {
            animator.SetBool("isRunning", true);
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigbod.velocity = movementInput * speed; // Bewegung des Charakters berechnen und an den Rigidbody übertragen
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
