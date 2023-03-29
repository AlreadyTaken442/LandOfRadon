using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public bool isFull;
    public GameObject inHand;




    public void EmptyHand()
    {
        if (isFull)
        {
            isFull = false;
            GameObject.Destroy(inHand);
        }
    }
}
