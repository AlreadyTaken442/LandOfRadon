using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Charakter : MonoBehaviour // Definition der Charakter-Klasse
{
    public float speed; // Geschwindigkeit des Charakters
    [SerializeField] private InputActionReference movement; // Referenz auf eine InputAction, die die Bewegung des Charakters steuert
    private Rigidbody2D rigbod; // Rigidbody2D-Komponente des Charakters
    private Vector2 movementInput; // Eingabewerte für die Bewegung des Charakters

    public Transform target; // Ziel-Transform des Charakters (nicht verwendet)

    private void Start()
    {
        rigbod = GetComponent<Rigidbody2D>(); // Initialisierung des Rigidbody2D-Komponente
    }

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>(); // Eingabewerte für die Bewegung lesen
    }

    private void FixedUpdate()
    {
        rigbod.velocity = movementInput * speed; // Bewegung des Charakters berechnen und an den Rigidbody übertragen
    }
}
