using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    private Rigidbody2D _RG2D;

    // Start is called before the first frame update
    void Start()
    {
        _RG2D = GetComponent<Rigidbody2D>();

        _RG2D.AddForce(transform.right * -1400);
        // _RG2D.velocity = new Vector3(10, 0, 0);
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<ITakeDamage>().TakeDamage(1);

        

        }
        if (collision.CompareTag("Wall"))
        {


            Destroy(gameObject);

        }



    }
}
