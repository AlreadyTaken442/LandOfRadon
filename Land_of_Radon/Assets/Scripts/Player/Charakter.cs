using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Charakter : MonoBehaviour // Definition der Charakter-Klasse
{

    private Transform playerHand;
    private Transform linkesBein;
    private Transform rechtesBein;

    public float speed; // Geschwindigkeit des Charakters
    [SerializeField] private InputActionReference movement; // Referenz auf eine InputAction, die die Bewegung des Charakters steuert
    private Rigidbody2D rigbod; // Rigidbody2D-Komponente des Charakters
    private Vector2 movementInput; // Eingabewerte für die Bewegung des Charakters

    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public Animator animator;

    public Transform target; // Ziel-Transform des Charakters (nicht verwendet)

    // Speichere die letzte Laufrichtung des Charakters
    private Vector2 lastDirection = Vector2.right;

    // Verweise auf das Sprite-Renderer-Komponente des Charakters
    private GameObject gameObject1;

    private void Start()
    {
        rigbod = GetComponent<Rigidbody2D>(); // Initialisierung des Rigidbody2D-Komponente
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameObject1 = GetComponent<GameObject>();

        playerHand = transform.Find("PlayerObj/Player/PlayerHand");
        linkesBein = transform.Find("PlayerObj/Player/LinkesBein");
        rechtesBein = transform.Find("PlayerObj/Player/RechtesBein");

        // Test ob Objekte gefunden wurden
        if (playerHand == null)
        {
            Debug.LogError("PlayerHand konnte nicht gefunden werden!");
        }

        if (linkesBein == null)
        {
            Debug.LogError("LinkesBein konnte nicht gefunden werden!");
        }

        if (rechtesBein == null)
        {
            Debug.LogError("RechtesBein konnte nicht gefunden werden!");
        }
    }

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>(); // Eingabewerte für die Bewegung lesen

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
        }

        if (movementInput.x == 0 && movementInput.y == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }

        // Bewege den Charakter in die ausgewählte Richtung
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        transform.Translate(direction * speed * Time.deltaTime);

        //Spiegle das Sprite, wenn sich die Laufrichtung ändert
        if (direction != Vector2.zero)
        {
            lastDirection = direction;
            if (lastDirection.x > 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if (lastDirection.x < 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
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
