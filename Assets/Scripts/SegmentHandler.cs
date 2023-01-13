using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _DoorToNextSegmet;
    public GameObject _Spawners1;
    public GameObject _Spawners2;
    public bool EnemiesActive;
    public int enemiesSpawned1;
    public int enemiesSpawned2;


    private bool secondSpawnersStarted = false;
    public int enemiesLeft;
    void Start()
    {
        if (_DoorToNextSegmet != null)
        {
            _DoorToNextSegmet.SetActive(false);
        }
      
       
        if (_Spawners2 != null)
        {

            _Spawners2.SetActive(false);
        }
        if (_Spawners1 != null)
        {

            _Spawners1.SetActive(false);
        }
        if (_DoorToNextSegmet != null)
        {

            _DoorToNextSegmet.SetActive(false);

        }
        SpawnEnemies();

    }



    public void SpawnEnemies()
    {

        //enemiesLeft = enemiesSpawned1;
        _Spawners1.SetActive(true);


    }

    public void RemoveEnemyFromPool()
    {
        enemiesLeft -= 1;
        if (enemiesLeft == 0)
        {
            if (_Spawners2 == null)
            {
                Debug.Log("DoorOpen");
                if(_DoorToNextSegmet!= null) {
                    _DoorToNextSegmet.SetActive(true);
                }

            }
            else if(_Spawners2 !=null && !secondSpawnersStarted)
            {
                secondSpawnersStarted = true;
                _Spawners2.SetActive(true);

            }
            else if (_Spawners2 != null && secondSpawnersStarted)
            {

                _DoorToNextSegmet.SetActive(true);

            }


        }
    }

    public void AddEnemyToPool(int numberOf)
    {

        enemiesLeft = enemiesLeft + numberOf;


    }
}
    

