using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charakter : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Horizontale Bewegung
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0, 0);

        float verticalInput = Input.GetAxis("Vetical") * speed * Time.deltaTime; //Vertiakle Bewerbung
        Vector3 newPosition1 = transform.position + new Vector3(verticalInput, 0, 0);
    }
}
