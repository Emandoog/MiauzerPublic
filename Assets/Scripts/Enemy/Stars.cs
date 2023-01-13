using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stars : MonoBehaviour, ITakeDamage
{
    public GameObject _BulletSlime;
    public Transform player;
    public Rigidbody2D _RB2d;
    public int life = 3;
    public float attackRange = 10f;
    private float speed = 1f;
    private float timeToShoot;
    private float startShooting = 2f;
    private NavMeshAgent _Agent;
    private Animator _Animator;
    private bool wasAttacking;
    private bool dead = false;

    private GameObject _SFX;
    private void OnEnable()
    {
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.updateRotation = false;
        _Agent.updateUpAxis = false;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _RB2d = this.GetComponent<Rigidbody2D>();
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.updateRotation = false;
        _Agent.updateUpAxis = false;
        _Animator = GetComponent<Animator>();
        _SFX = GameObject.FindGameObjectWithTag("SFX");
        //HeartyShoot();
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
        if (Vector2.Distance(transform.position, player.position) > attackRange)
        {
            _Agent.isStopped = false;
            _Agent.destination = player.position;
            if (wasAttacking)
            {
                wasAttacking = false;
                //_Animator.Play("HeartyWalk");
            }

            //  transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            wasAttacking = true;
            _Agent.isStopped = true;
            _Animator.Play("StarsAttack");
                
                //_Agent.isStopped = true;
                //if (timeToShoot <=0 )
                //{
                //    timeToShoot = startShooting;

                //    Instantiate(_BulletSlime, transform.position, Quaternion.identity);

                //}
                //else {
                //    timeToShoot -= Time.deltaTime;

                // }

            }
        }
    }

    public void TakeDamage(int Damage)
    {
        life -= Damage;
       
        if (life <= 0)
        {
            dead = true;
            gameObject.layer = 11;
            _Animator.Play("StarsDeath");

        }

    }
    public void StarsShoot()
    {
        _SFX.GetComponent<SFXH>().StarAttackSFX();
        int temp = 0;
        for (int i = 0; i<=4; i++) 
        {

            Debug.Log(temp);
            var temp2 = Instantiate(_BulletSlime, transform.position, Quaternion.identity);
            temp2.GetComponent<StarAttack>().Direction2(temp);
           
            //Instantiate(_BulletSlime, transform.position, Quaternion.identity);
            temp++;
           
           // Debug.Log(temp);
        }
    }
    public void Die() 
    {
        //dead = true;
        // gameObject.layer = 11;
        _SFX.GetComponent<SFXH>().EnemyDeathSFX();
        Destroy(gameObject);
        if (GetComponentInParent<Espawner>() != null)
        {
            GetComponentInParent<Espawner>().RemoveEnemy();
        }

    }

}
