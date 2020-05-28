using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController playerController;

    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Rigidbody2D rb2d;
    [HideInInspector]
    public CapsuleCollider2D capsule;

    public float jumpForce;
    public int speed;

    public Transform tipPosition;
    public GameObject projectile;

    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        capsule = GetComponent<CapsuleCollider2D>();


    }

    public void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void Update()
    {
        
        playerController.playerJump();
        playerController.PlayerCrouch();
        playerController.PlayerAttack();
        //playerController.PlayerHurt();
    }

    private void LateUpdate()
    {
        playerController.playerRun();
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            playerController.PlayerPush(true);
           
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            playerController.PlayerPush(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyTriggerAttack"))
        {

            animator.SetBool("Hurt", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyTriggerAttack"))
        {

            animator.SetBool("Hurt", false);
        }
    }

}
