using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int openingDirection;
    /*
     1--> need bottom door
     2--> need top dor
     3--> need left room
     4--> need right room
     */

    private RoomTemplates templates;
    private int rand,test=1;
    private bool spawned = false;

    private void Start() 
    {
        Debug.Log("Text: kurwa");
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();

        if (test == 1)
        {
            Spawn();
        }
        test++;
        Debug.Log(test);
    }   
    
    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                //bottom
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                //top
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                //letf
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                // right
            }

            spawned = true;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("dlaczego");
        if (other.CompareTag("SpawnPoint") && other.GetComponent<Room>().spawned == true) 
        {
            Destroy(gameObject);
            Debug.Log("test");
        }
    }
}
