using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKwhy : MonoBehaviour
{
    public Rigidbody2D _Bullet;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        _Bullet =gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject,6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Direction(int ii) 
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
            _Bullet.velocity = new Vector3(0, -speed, 0);
        }
        else if (ii == 4)
        {
            _Bullet.velocity = new Vector3(speed*0.75f, speed*0.75f ,0);
        }
        else if (ii == 5)
        {
           // Debug.Log("alive");
            _Bullet.velocity = new Vector3(-speed * 0.75f, -speed * 0.75f, 0);
        }
        else if (ii == 6)
        {
            _Bullet.velocity = new Vector3(-speed * 0.75f, speed * 0.75f, 0);
        }
        else if (ii == 7)
        {
            _Bullet.velocity = new Vector3(speed * 0.75f, -speed * 0.75f, 0);
        }
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
