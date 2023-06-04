using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioClip menuSong;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(menuSong , 1f);
    }

    
    void Update()
    {
       
    }
}
