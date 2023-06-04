using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float timer;
    public int spawnrate;
    public float heightoffset = 10;

    void Start()
    {
        spawnpipe();
    }

    
    void Update()
    {
        if (timer<spawnrate) {
            
            timer = timer + Time.deltaTime;
}
        else
        {
            spawnpipe();
            timer = 0;
        }
        
    }
    void spawnpipe()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;

        Instantiate(pipe, new Vector3(transform.position.x , Random.Range(lowestpoint,highestpoint) , 0), transform.rotation);
    }
}
