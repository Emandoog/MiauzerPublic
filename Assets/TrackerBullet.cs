using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TrackerBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D sbullet;
    private Vector2 target;
    public float speed=2;
    private NavMeshAgent _Agent;
    public GameObject newBullet;


    private void OnEnable()
    {
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.updateRotation = false;
        _Agent.updateUpAxis = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        sbullet = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(End());
        //gameObject.transform.rotation.SetLookRotation(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.rotation.SetLookRotation(player.transform.position);
    }
     
    private void FixedUpdate()
    {
        //Quaternion rotation = Quaternion.LookRotation
        //(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        //transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        transform.right = (player.position - transform.position)*-1;
        transform.position = Vector2.MoveTowards(transform.position ,player.position, speed * Time.deltaTime);

        if (transform.position == player.position) 
        {
            Explode();
        
        }
       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage(1);
            //waExplode();
            Destroy(gameObject);

        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator End() 
    {
        yield return new WaitForSeconds(7);
        Explode();
   
    }

    public void Explode()
    {
        int temp = 0;

        for (int i = 0; i <= 7; i++)
        {
            var temp2 = Instantiate(newBullet, transform.position +new Vector3(0,0,0), Quaternion.identity);
            temp2.GetComponent<OKwhy>().Direction(temp);
            temp++;
        }
        Destroy(gameObject);
    }
}
