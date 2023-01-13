using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySlime : MonoBehaviour,ITakeDamage
{
    public Transform player;
    public Rigidbody2D _RB2D;
    public int life = 3;
    public float attackRange = 10f;
    private float speed =2f;
    private NavMeshAgent _Agent;
    private Animator _MellowAnimator;
    private bool coughtPlayer;
    public GameObject _BoomZone;
    private GameObject _SFX;

    private void OnEnable()
    {
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.updateRotation = false;
        _Agent.updateUpAxis = false;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _MellowAnimator = GetComponent<Animator>();
        _RB2D = this.GetComponent<Rigidbody2D>();
        
        _SFX = GameObject.FindGameObjectWithTag("SFX");

    }

   
    void Update()
    {
        //Vector3 direction= player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(direction);
       // _Agent.destination = player.position;
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
        if (!coughtPlayer) 
        {

            _Agent.destination = player.position;


        }
        if (player.position.x> gameObject.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;


        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;


        }
    }
    public void TakeDamage(int Damage) 
    {
        life -= Damage;
        Debug.Log("Enemy Took "+Damage);
        if (life <= 0) 
        {
           // _SFX.GetComponent<SFXH>().EnemyExplosionSFX();
            _MellowAnimator.Play("MellowBoom");

        }
    
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("hit someting");
        if (collision.CompareTag("Player"))
        {

            //_SFX.GetComponent<SFXH>().EnemyExplosionSFX();
            _MellowAnimator.Play("MellowBoom");
           // Debug.Log("hit Plyer");
            //collision.GetComponent<PlayerController>().TakeDamage(1);



        }
    }
    public void Boom()
    {
        coughtPlayer = true;
        _Agent.isStopped = true;
       
        var temp = Instantiate(_BoomZone, transform.position,Quaternion.Euler(0,0,0));
        _SFX.GetComponent<SFXH>().EnemyExplosionSFX();
        temp.SetActive(true);
           Destroy(gameObject,0.4f);

        if (GetComponentInParent<Espawner>() != null) 
        {
            GetComponentInParent<Espawner>().RemoveEnemy();
        }
        //collision.GetComponent<PlayerController>().TakeDamage(1);
        //check if player is in range
        //deal dmg
        //dissapear



    }
}
