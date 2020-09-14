using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public ParticleSystem explosinParticle;
    public ParticleSystem dirtPartcle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool gameOver;

    private Rigidbody playerRb;
    private Animator animator;
    private AudioSource audioSource;
    private float jumpForce = 700f;
    private float gravityModifier = 1.5f;
   
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        isOnGround = true;
        gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtPartcle.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);

        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtPartcle.Play();

        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosinParticle.Play();
            dirtPartcle.Stop();
            audioSource.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over");
        }
    }

}
