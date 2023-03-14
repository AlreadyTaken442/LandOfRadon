using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //Damit lässt sich asuwählen, welches Objekt das Ziel ist. (Muss in Unity festgellegt werden)
    public Vector3 offset = new Vector3(0, 0, -10); //Legt den Abstand fest

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
