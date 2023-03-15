using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //wichtig f�r Text-Objekt

public class DisplayHealth : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText; //TextMeshProUGUI ist f�r speziellen Text (TMro)

    private void Update()
    {
        healthText.text = " : " + health; //Output

        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }

        if (health < 0)
        {
            health = 0;
        }
    }
}
