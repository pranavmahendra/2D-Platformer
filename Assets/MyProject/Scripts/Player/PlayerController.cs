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

    private bool m_FacingRight = true;

    

    //Player Run Logic
    public void playerRun()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        
        playerView.animator.SetFloat("Speed", Mathf.Abs(speed));

        //Flip the character.
        //Speed more than 0 and facing left.
        if(speed > 0 && !m_FacingRight)
        {
            
            Flip();
        }
        else if (speed < 0 && m_FacingRight)
        {
            
            Flip();
        }

        
        void Flip()
        {
            m_FacingRight = !m_FacingRight;

            playerView.transform.Rotate(0f, 180f, 0f);
        }

        if (isCrouching == false)
        {
            if(!m_FacingRight)
            {
                playerView.transform.Translate(speed * playerView.speed * -1f * Time.deltaTime, 0f, 0f);
            }
            else
            {
                //Default
                playerView.transform.Translate(speed * playerView.speed * 1f * Time.deltaTime, 0f, 0f);
            }
            
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
        playerView.animator.SetBool("Crouch", isCrouching);
        
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

            EllenFire();
             
            //Playing audio logic
            playerView.audioSource.clip = playerView.audioClips[2];
            playerView.audioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isAttacking = false;

            playerView.audioSource.Stop();
    
        }
        playerView.animator.SetBool("Attack", isAttacking);
    }

    //Hurt Logic
    public void PlayerHurt()
    {
        //EnemyService.Instance.enemyController.enemyView.enemyAttack.isAttacking += enemyAtAttacking;

        playerView.animator.SetBool("Hurt", isHurt);

    }

    //Damage Logic
    public void TakeDamage(int projectileDamage)
    {
        PlayerModel.health = PlayerModel.health - projectileDamage;
        if (PlayerModel.health <= 0)
        {
            playerView.gameObject.SetActive(false);
            Debug.Log("Player has died.");
        }
        else
        {
            Debug.Log("Player took damage of:" + projectileDamage + ".");
            Debug.Log("Updated health of player is " + PlayerModel.health + ".");
        }
    }

    //Ellen Creating Bullet Logic
    public void EllenFire()
    {
        BulletService.Instance.CreateEllenBullet().setPosition(playerView.tipPosition.position, playerView.tipPosition.rotation);
      
    }

}

