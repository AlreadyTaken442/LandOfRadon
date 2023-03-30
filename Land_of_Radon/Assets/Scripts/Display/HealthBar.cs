using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Eine öffentliche Referenz auf den Slider, der die Gesundheitsanzeige darstellt.
    public Slider slider;

    // Eine öffentliche Methode, um die maximale Gesundheit zu setzen.
    // Hier wird der Maximalwert des Sliders auf die übergebene Gesundheit gesetzt und der aktuelle Wert auf den Maximalwert gesetzt.
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Eine öffentliche Methode, um die aktuelle Gesundheit zu setzen.
    // Hier wird der Wert des Sliders auf die übergebene Gesundheit gesetzt.
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
