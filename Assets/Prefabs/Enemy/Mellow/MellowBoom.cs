using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MellowBoom : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.1f);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage();
        
        
        }
    }
}
