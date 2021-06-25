using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;
    private Rigidbody2D playerrigidbody2D;
    private Animator animator;
    private AudioSource playerAudio;

    private void Start()
    {
        playerrigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }
    private void Die()
    {
        //Á×À½ ±¸Çö
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //DeadÁ¸ Triggering
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //¹Ù´Ú °¨Áö
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //¹Ù´Ú ¶³¾îÁü °¨Áö
    }

}
