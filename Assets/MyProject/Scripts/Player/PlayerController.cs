using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    public PlayerController(PlayerModel playerModel, PlayerView playerPrefab)
    {
        PlayerModel = playerModel;
        playerPrefab = GameObject.Instantiate<PlayerView>(playerPrefab);
        this.playerView = playerPrefab;
        Debug.Log("Elen player has been created");

        playerPrefab.Initialize(this);
    }

    public PlayerModel PlayerModel { get; }
    public PlayerView playerView { get; }

    public bool isJumping;
    public bool isMoving;
    public bool isCrouching;
    public bool isAttacking;
    public bool isHurt;



    //Player Run Logic
    public void playerRun()
    {
        float speed = Input.GetAxisRaw("Horizontal");
  
        playerView.animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = playerView.transform.localScale;

        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);   
        }
     
        if(speed != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        playerView.transform.localScale = scale;
 
        if (isCrouching == false & isAttacking == false)
        {
             playerView.transform.Translate(Vector3.right * speed * playerView.speed * Time.deltaTime);
        }
    }

    //Jump Logic
    public void playerJump()
    {
 
        if(Input.GetKeyDown(KeyCode.Space) && isCrouching == false)
        {
            isJumping = true;
            playerView.rb2d.AddForce(new Vector2(0f, playerView.jumpForce), ForceMode2D.Impulse);
            playerView.transform.Translate(Vector3.up * playerView.speed * Time.deltaTime);

            //Playing audio logic
            playerView.audioSource.clip = playerView.audioClips[1];
            playerView.audioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            playerView.audioSource.Stop();
        }
      
        playerView.animator.SetBool("Jump", isJumping);
    }

    //Crouch Logic
    public void PlayerCrouch()
    {
        if(Input.GetKey(KeyCode.C))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
        playerView.animator.SetBool("Crouch",isCrouching);
    }

    //Push Logic
    public void PlayerPush(bool isPushing)
    {
        playerView.animator.SetBool("Push",isPushing);
    
    }

    //Attack Logic
    public void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
      
            //Playing audio logic
            playerView.audioSource.clip = playerView.audioClips[2];
            playerView.audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isAttacking = false;

            playerView.audioSource.Stop();
    
        }
        playerView.animator.SetBool("Attack", isAttacking);
    }

    //Hurt Logic
    public void PlayerHurt()
    {
        EnemyService.Instance.enemyController.enemyView.enemyAttack.isAttacking += enemyAtAttacking;

        playerView.animator.SetBool("Hurt", isHurt);
    }

    private void enemyAtAttacking()
    {
        isHurt = true;
    }
}

