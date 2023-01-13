using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    private Animator _Animator;
    public GameObject _DamageZone;
    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        //_Animator.Play
    }

    
    

    public void DealDamage()
    {


        var temp = Instantiate(_DamageZone, transform.position, Quaternion.Euler(0, 0, 0));
        temp.transform.parent = gameObject.transform;
        temp.SetActive(true);
        //Destroy(gameObject, 0.4f);

    }   
    public void Die() 
    {
        Destroy(gameObject);
    
    
    }
}
