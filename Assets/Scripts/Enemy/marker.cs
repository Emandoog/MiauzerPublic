using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeToDie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timeToDie() 
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
