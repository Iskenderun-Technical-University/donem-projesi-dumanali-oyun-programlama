using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float jumppower;
    private LogicScript logic;
    public bool birdIsAlive = true;
    public AudioClip jumpFX;
    public AudioClip crashFX;
    public AudioSource playerAudio;
    
  

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        playerAudio = GetComponent<AudioSource>();
      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) { 


            playerRB.velocity = Vector2.up * jumppower;
            playerAudio.PlayOneShot(jumpFX, 1.0f);
        }

        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerAudio.PlayOneShot(crashFX, 1.0f); 
        logic.gameover();
        birdIsAlive = false;
      
    }
}
