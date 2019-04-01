using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector2 direction;
    public float speed = 15f;
    Transform player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        int x = Random.Range(1, 10);

        if (x % 2 == 0)
        {
            direction = (player.position - transform.position).normalized;
            //towards player
        }
        else
        {
            direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            //Random direction
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }
}
