using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject _WeaponToPickUP;
    public GameObject _SegmentHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _WeaponToPickUP.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {

            if (_SegmentHandler != null)
            { 
                    _SegmentHandler.SetActive(true);
            }
            collision.gameObject.GetComponentInChildren<WeaponHandler>().GiveWeapon(_WeaponToPickUP);
            Destroy(gameObject);
        }
    }


}
