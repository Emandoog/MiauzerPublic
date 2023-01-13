using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _RG2D;
    public  int damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _RG2D = GetComponent<Rigidbody2D>();
       // Debug.Log(transform.right);
        _RG2D.AddForce(transform.right * -1000);
        // _RG2D.velocity = new Vector3(10, 0, 0);
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<ITakeDamage>().TakeDamage(damage);

            Destroy(gameObject);
        
        }
        if (collision.CompareTag("Wall"))
        {
            

            Destroy(gameObject);

        }



    }
}
