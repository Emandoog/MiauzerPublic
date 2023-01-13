using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, ITakeDamage
{
    public Transform player;
    public Rigidbody2D slime;
    public GameObject MachineGun;
    public GameObject MachineGun2;
    public GameObject markPlayer;
    public int life = 3;
    private int numberOfAttacks = 100;
    private int choosenAttacks;
    public float attackRange = 10f;
    private float speed = 2f;
    private float time;
    private float angel = 10 ;
    private bool fin = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        slime = this.GetComponent<Rigidbody2D>();
        StartCoroutine(BOSS());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int Damage)
    {
        life -= Damage;
        Debug.Log("Enemy Took " + Damage);
        if (life <= 0)
        {
            Debug.Log("Enemy Dead");
            Destroy(gameObject, 2);

        }

    }
    IEnumerator BOSS()
    {
        yield return new WaitForSeconds(1);
        choosenAttacks = Random.Range(0, numberOfAttacks);
        Debug.Log("XD");
        Debug.Log(choosenAttacks);
        //fire();
        if (choosenAttacks < 15)
        {
            //StartCoroutine(BoosMachineGun());
        }
        else if (choosenAttacks < 31 && choosenAttacks > 15)
        {

        }
        else if (choosenAttacks < 47 && choosenAttacks > 31)
        {
        }
        else if (choosenAttacks < 63 && choosenAttacks > 47)
        {
        }
        else if (choosenAttacks < 79 && choosenAttacks > 63)
        {
        }
        else {
        }
    }
    IEnumerator BoosMachineGun()
    {
        for (int i = 0; i <= 120; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(MachineGun, transform.position, Quaternion.identity);
        }
        StartCoroutine(BOSS());
    }
    private void sec() 
    {
        Instantiate(markPlayer, player.position, Quaternion.identity);
    }
    /*private void fire() 
    {
        float buldirX = transform.position.x + Mathf.Sin((angel*Mathf.PI)/180f);
        float buldiry = transform.position.y + Mathf.Cos((angel*Mathf.PI)/180f);
        Vector3 bulM = new Vector3(buldirX, buldiry, 0f);
        Vector3 buldir = (bulM - transform.position).normalized;

        //MachineGun2.SetActive(true);
        //MachineGun2.GetComponent
        var temp = Instantiate(MachineGun2, transform.position, Quaternion.identity);
        temp.GetComponent<curvingBullet>().why(buldir);
       

    }*/
}
