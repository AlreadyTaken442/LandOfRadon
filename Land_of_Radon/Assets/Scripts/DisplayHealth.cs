using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;

    private void Update()
    {
        healthText.text = " : " + health;

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
