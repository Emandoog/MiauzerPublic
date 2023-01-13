using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator _Animator;
    public GameObject _TransportPoint;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();


    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            _player = collision.gameObject;
            _Animator.Play("FadeTwoBlack");




        }
    }

    public void Transport() 
    {

        _player.transform.position = _TransportPoint.transform.position;
      

    }
    public void Stop()
    {
        _Animator.Play("New State");

    }
   
}
