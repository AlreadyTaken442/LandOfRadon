using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLongRange : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float distancebetween;
    private float distance;
    public GameObject projectille;
    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0 && distance < distancebetween)
        {
            Instantiate(projectille, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
