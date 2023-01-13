using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSegment : MonoBehaviour
{
    public GameObject _SegmentHandler;
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // collision.gameObject.GetComponent<PlayerController>().TakeDamage();
            int lifetoheal = collision.gameObject.GetComponent<PlayerController>().maxLife - collision.gameObject.GetComponent<PlayerController>().life;
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(-lifetoheal);
            _SegmentHandler.SetActive(true);
            Destroy(gameObject);

        }
    }
}
