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

    public float jumpForce;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void Update()
    {
        playerController.playerRun();
        playerController.playerJump();
        playerController.PlayerCrouch();
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


}
