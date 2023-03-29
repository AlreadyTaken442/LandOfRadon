using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;
    public GameObject destinationPortal;

    public float offsetX;
    public float offsetY;
    public bool isGreen;
    public float distance = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        destination = destinationPortal.transform;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<Transform>(out Transform playerComponent))
            {
            playerComponent.position = new Vector3(destination.position.x + offsetX, destination.position.y + offsetY);
        }

    }
}
