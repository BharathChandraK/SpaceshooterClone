using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;

    public GameObject bulletprefab;

    public GameObject Enemyprefab;

    float verticalExtent;
    float horizontalExtent; 

	// Use this for initialization
	void Start ()
    {
        verticalExtent = Camera.main.orthographicSize;
        horizontalExtent = verticalExtent * Camera.main.aspect;

        InvokeRepeating("EnemyGenerator", 1, 1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        mouseface();
        shoot();
        
    }

    void mouseface()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);
        transform.up = dir;
    }

    void shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletprefab, player.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = 50f * transform.up;
            Destroy(bullet, 3f);
        }
    }

    void EnemyGenerator()
    {
        int x = Random.Range(1, 4);
        switch (x)
        {
            case 1://Up
                Instantiate(Enemyprefab, new Vector2(Random.Range(-horizontalExtent, horizontalExtent), verticalExtent), Quaternion.identity);
                break;
            case 2://Down
                Instantiate(Enemyprefab, new Vector2(Random.Range(-horizontalExtent, horizontalExtent), -verticalExtent), Quaternion.identity);
                break;
            case 3://right
                Instantiate(Enemyprefab, new Vector2(horizontalExtent, Random.Range(-verticalExtent, verticalExtent)), Quaternion.identity);
                break;
            case 4://right
                Instantiate(Enemyprefab, new Vector2(-horizontalExtent, Random.Range(-verticalExtent, verticalExtent)), Quaternion.identity);
                break;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            gameObject.SetActive(false);
            Destroy(collision.transform.gameObject);
        }
    }
}
