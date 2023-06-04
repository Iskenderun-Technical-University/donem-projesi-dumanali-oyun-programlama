using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpeed : MonoBehaviour
{
    public float speed;
    public int deadzone = -45;

    void Start()
    {
        
    }

    
    void Update()
    {
    transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;
        
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    
    }

}
