using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private bool work = true;
    private GameObject _SegmentHandler;

    private bool startedSpawning = false;
    public int enemiesToSpawn = 1;
    private void Start()
    {
        //StartCoroutine(SpawnEnemy());

        SpawnEnemy();

    }
    private void OnEnable()
    {
       
      
    }

    public void SpawnEnemy() 
    {

        if (startedSpawning == false)
        {
            gameObject.GetComponentInParent<SegmentHandler>().AddEnemyToPool(enemiesToSpawn);
            startedSpawning = true;



        }
        Debug.Log("spawninig");

        Debug.Log("spawninig2");
        if (work == true && enemiesToSpawn > 0)
        {
            Debug.Log("spawninig");
            int randEnemy = Random.Range(0, enemyPrefab.Length);
            var clone = Instantiate(enemyPrefab[randEnemy], transform.position, transform.rotation);
            clone.SetActive(true);
            clone.transform.parent = gameObject.transform;
            enemiesToSpawn -= 1;

        }
        else
        {
            Debug.Log("sleep");
        }
        //yield return new WaitForSeconds(0);
        //StartCoroutine(SpawnEnemy());


    }
    //IEnumerator SpawnEnemy()
    //{
        
       

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            work = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            work = true;
        }
    }
    public void RemoveEnemy() 
    {
        //gameObject.GetComponentInParent<SegmentHandler>().AddEnemyToPool(enemiesToSpawn);
        gameObject.GetComponentInParent<SegmentHandler>().RemoveEnemyFromPool();

    }
}
