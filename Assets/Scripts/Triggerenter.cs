using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Triggerenter : MonoBehaviour
{

    public LogicScript logic;
    public AudioClip scoreFX;
    public AudioSource scoreFXSource;

    void Start()
    {
         logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        scoreFXSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore();
        scoreFXSource.PlayOneShot(scoreFX , 1.0f);
        
    }
}
