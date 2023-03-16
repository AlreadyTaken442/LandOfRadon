using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealthEnemy = 100;
    public  int currentHealthEnemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthEnemy = maxHealthEnemy;
    }

    public void TakeDamage(int damage)
    {
        currentHealthEnemy -= damage;

        if (currentHealthEnemy <= 0)
        {
            Die();
        }
        if (currentHealthEnemy <= 0)
        {
            currentHealthEnemy = 0;
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
    }
}
