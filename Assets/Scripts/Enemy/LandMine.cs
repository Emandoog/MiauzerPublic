using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    private Rigidbody2D sbullet;
    public float speed;
    private float x, y;
    private float randx,randy;
    private Animator _Animator;

    private Transform player;
    private Vector2 target;
    public GameObject _Parent;
    private GameObject _SFX;

    public bool hitWall;
    void Start()
    {
        sbullet = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        randx = Random.Range(-5,5);
        randy = Random.Range(-5,5);
        target = new Vector2(player.position.x + randx, player.position.y + randy);
        x = player.position.x;
        y = player.position.y;
       // speed = 10;
        Destroy(_Parent.gameObject, 10);
        _Animator = GetComponent<Animator>();
        _Animator.Play("MineFloat");
        _SFX = GameObject.FindGameObjectWithTag("SFX");
    }

    void Update()
    {
        if (!hitWall)
        {
            _Parent.transform.position = Vector2.MoveTowards(_Parent.transform.position, target, speed * Time.deltaTime);
        }
        if (transform.position.x == x && transform.position.y == y)
        {
            _Animator.enabled = true;
            _Animator.Play("MineFloat");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage();
            _SFX.GetComponent<SFXH>().EnemyExplosionSFX();
            Destroy(_Parent.gameObject);

        }
        if (collision.CompareTag("Wall"))
        {
            hitWall = true;
            _Animator.enabled = true;
            _Animator.Play("MineFloat");
        }
    }
}
