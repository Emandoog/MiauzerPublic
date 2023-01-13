using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class shootingSlime : MonoBehaviour , ITakeDamage
{
    public GameObject _BulletSlime;
    public Transform player;
    public Rigidbody2D slime;
    public int life = 3;
    public float attackRange = 10f;
    private float speed = 1f;
    private float timeToShoot;
    private float startShooting = 2f;
    private NavMeshAgent _Agent;
    private Animator _Animator;
    private bool wasAttacking;
    private GameObject _SFX;

    private bool dead = false;

    private void OnEnable()
    {
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.updateRotation = false;
        _Agent.updateUpAxis = false;
        _SFX = GameObject.FindGameObjectWithTag("SFX");
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        slime = this.GetComponent<Rigidbody2D>();
         
        _Animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (!dead) { 
            if (player.position.x > gameObject.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;


            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;


            }
            if (Vector2.Distance(transform.position, player.position) > 10)
            {
                _Agent.isStopped = false;
                _Agent.destination = player.position;
                if (wasAttacking) 
                {
                    wasAttacking = false;
                  _Animator.Play("HeartyWalk");
                 }

           
            }
            else 
            {
                wasAttacking = true;
                _Agent.isStopped = true;

           
                _Animator.Play("HeartyAttack");


            }
        }
    }

    public void TakeDamage(int Damage)
    {
        life -= Damage;
       
        if (life <= 0)
        {
            gameObject.layer = 11;
            dead = true;
            _Animator.Play("HeartyDeath");

        }

    }
    private void Die()
    {
        _SFX.GetComponent<SFXH>().EnemyDeathSFX();
        if (GetComponentInParent<Espawner>() != null)
        {
            GetComponentInParent<Espawner>().RemoveEnemy();
        }
        Destroy(gameObject);
    
    }
    public void HeartyShoot()
    {
       
        Instantiate(_BulletSlime, transform.position, Quaternion.identity);
    }

}
