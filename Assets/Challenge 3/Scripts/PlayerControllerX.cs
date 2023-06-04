using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    private float speed;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    private float yLimit = 14f;
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


   
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

    }

   
    void Update()
    {
        if (!gameOver) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce , ForceMode.Impulse);
        }
        if (transform.position.y >= yLimit && !gameOver)
        {
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
            playerRb.AddForce(Vector3.down * 5 , ForceMode.Impulse);
        }
        if (transform.position.y <= 1.5f && !gameOver) {

            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
            playerRb.AddForce(Vector3.up * 0.2f  , ForceMode.Impulse);
        }
        else if (transform.position.y < 0) {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

       
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
