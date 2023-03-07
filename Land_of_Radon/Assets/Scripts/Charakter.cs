using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Charakter : MonoBehaviour
{
        public float speed;
        [SerializeField] private InputActionReference movement;
        private Rigidbody2D rigbod;
        private Vector2 movementInput;

        public Transform target;

        private void Start()
            {
                rigbod = GetComponent<Rigidbody2D>();
            }

            // Update is called once per frame
            void Update()
            {
                movementInput = movement.action.ReadValue<Vector2>();
            }

            private void FixedUpdate()
            {
                rigbod.velocity = movementInput * speed;
            }
    }
