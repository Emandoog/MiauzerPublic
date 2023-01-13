using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsBullet : MonoBehaviour
{
    private Rigidbody2D _RG2D;
    public float speed;
    private float x, y;
    private Animator _Animator;

    private Transform player;
    private Vector2 target;
    //public GameObject _Parent;

    public bool hitWall;

    void Start()
    {
        _RG2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        x = player.position.x;
        y = player.position.y;
        speed = 10;
        Destroy(gameObject, 5);
        _Animator = GetComponent<Animator>();


        _RG2D.AddForce(transform.forward* 1000);

        //transform.LookAt(target);
        //.rotation = Quaternion.Euler(transform.rotation.x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage();

            Destroy(gameObject);

        }
        if (collision.CompareTag("Wall"))
        {
            hitWall = true;
            _Animator.enabled = true;
           
        }
    }
}
