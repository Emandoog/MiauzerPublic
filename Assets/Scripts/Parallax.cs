using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject _Camera;
    private float startPos;
    public float parallaxStrengh;
    // Start is called before the first frame update
    void Start()
    {
        _Camera = GameObject.FindGameObjectWithTag("Player");
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (_Camera.transform.position.x * parallaxStrengh);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.x);
    }
}
