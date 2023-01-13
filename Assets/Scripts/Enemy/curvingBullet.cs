using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvingBullet : MonoBehaviour
{
    private Rigidbody2D sbullet;
    public float speed;
    private float maxspeed = 0.8f;
    private float x, y;



    private Transform player;
    private Transform target;
    private Vector2 target2;
    private  Vector2 direction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sbullet = gameObject.GetComponent<Rigidbody2D>();
        target = player.transform;
        target2 = player.transform.position;

        x = player.position.x;
        y = player.position.y;
        // transform.right = (player.position - transform.position) * -1;

        /* player = GameObject.FindGameObjectWithTag("Player").transform;
         target = new Vector2(player.position.x, player.position.y);
         x = player.position.x;
         y = player.position.y;
         speed = 1 * Time.deltaTime;*/
        //InvokeRepeating("fire",0f,0.1f);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        direction = (target.transform.position - transform.position).normalized;

        sbullet.AddForce(direction * 7);
        // _RG2D.velocity = new Vector3(10, 0, 0);
        Destroy(gameObject, 15);
        //transform.position = Vector2.MoveTowards(transform.position, target2, speed * Time.deltaTime);
        //if (transform.position.x == x &&  transform.position.y == y)
        //{
        //    Destroy(gameObject);
        //}        
        //sbullet.AddForce(transform.right * 1000);
    }
    public void why(Vector3 yes) 
    {
        Debug.Log(yes);
        direction = yes;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage(1);
            
            Destroy(gameObject);

        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
