using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAttack : MonoBehaviour
{
    public Rigidbody2D _Bullet;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        _Bullet = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Direction2(int ii) 
    {
        //Debug.Log(ii);
        if (ii == 0)
        {
            _Bullet.velocity = new Vector3(speed, 0, 0);
        }
        else if (ii == 1)
        {
            _Bullet.velocity = new Vector3(0, speed, 0);
        }
        else if (ii == 2)
        {
            _Bullet.velocity = new Vector3(-speed, 0, 0);
        }
        else if (ii == 3)
        {
            _Bullet.velocity = new Vector3(speed*0.75f , -speed*0.75f ,0);
        }
        else if (ii == 4)
        {
            _Bullet.velocity = new Vector3(-speed * 0.75f, -speed * 0.75f, 0);
        }

        
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


            Destroy(gameObject);

        }



    }
}
