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

        if (isDead == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerrigidbody2D.velocity = Vector2.zero;
            playerrigidbody2D.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerrigidbody2D.velocity.y > 0)
        {
            playerrigidbody2D.velocity = playerrigidbody2D.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);

    }
    private void Die()
    {
        animator.SetTrigger("Dead");
        Debug.Log(playerAudio.clip+"Player.Dead");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerrigidbody2D.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.OnPlayerDead();
       //Dead µ¿ÀÛ ±¸Çö
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Dead ½ÇÇà
        Debug.Log(other.name+"Dead");
        if (other.tag == "Dead" && !isDead)
        {
            Debug.Log("Dead2");
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.tag);
        if(other.contacts[0].normal.y > 0.7f &&other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }
        //¹Ù´Ú °¨Áö
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        //¹Ù´Ú ¶³¾îÁü °¨Áö
    }

}
