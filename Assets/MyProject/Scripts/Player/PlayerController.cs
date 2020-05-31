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

    public float speed;

    //Player Run Logic
    public void playerRun()
    {

        speed = Input.GetAxisRaw("Horizontal");

        playerView.animator.SetFloat("Speed", Mathf.Abs(speed));

        PlayerService.Instance.invokeRun();
        //Flip the character.
        //Speed more than 0 and facing left.
        if (speed > 0 && !m_FacingRight)
        {
            isMoving = true;
            Flip();
        }
        else if (speed < 0 && m_FacingRight)
        {
            isMoving = true;
            Flip();
        }
        else
        {
            isMoving = false;
        }


        void Flip()
        {
            m_FacingRight = !m_FacingRight;

            playerView.transform.Rotate(0f, 180f, 0f);
        }

        if (isCrouching == false & isHurt == false)
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

            ////Playing audio logic
            //Play landing audio
            PlayerService.Instance.audioService.audioSources[1].clip = PlayerService.Instance.audioService.playerAudioClips[2];
            PlayerService.Instance.audioService.audioSources[1].Play();
           
            PlayerService.Instance.audioService.audioSources[1].loop = false;
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
            PlayerService.Instance.invokeAttack();
            //PlayerService.Instance.audioService.audioSources[1].clip = PlayerService.Instance.audioService.playerAudioClips[1];
            //PlayerService.Instance.audioService.audioSources[1].Play();
            //PlayerService.Instance.audioService.audioSources[1].loop = false;
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
        PlayerService.Instance.invokeHurt();
        //isHurt = true;
        playerView.animator.SetBool("Hurt", true);
        
    }


    //Damage Logic
    public void TakeDamage(int projectileDamage)
    {
        //Play sound.
        PlayerService.Instance.audioService.audioSources[1].clip = PlayerService.Instance.audioService.playerAudioClips[5];
        PlayerService.Instance.audioService.audioSources[1].Play();

        PlayerModel.health = PlayerModel.health - projectileDamage;
        if (PlayerModel.health <= 0)
        {
            playerView.gameObject.SetActive(false);
            HealthService.Instance.HealthAnims[3].SetBool("health", true);
            //HealthService.Instance.PlayerHIcons[3].enabled = false;
            PlayerService.Instance.InvokeDead();
        }
        else
        {
            PlayerHurt();
 
            Debug.Log("Player took damage of:" + projectileDamage + ".");
            Debug.Log("Updated health of player is " + PlayerModel.health + ".");
        }
    }


    //Ellen Creating Bullet Logic
    public void EllenFire()
    {
        BulletService.Instance.CreateEllenBullet().setPosition(playerView.tipPosition.position, playerView.tipPosition.rotation);
        
    }


    //Events which will happen on when specified health reaced.
    public void CheckHealth()
    {
       
        if (PlayerModel.health < 75)
         {
            HealthService.Instance.HealthAnims[0].SetBool("health", true);
            //HealthService.Instance.PlayerHIcons[0].enabled = false;
         }

        if (PlayerModel.health < 50 && PlayerModel.health > 25)
         {
            HealthService.Instance.HealthAnims[1].SetBool("health", true);
            //HealthService.Instance.PlayerHIcons[1].enabled = false;
         }

        if (PlayerModel.health < 25 && PlayerModel.health > 0)
         {
            HealthService.Instance.HealthAnims[2].SetBool("health", true);
            //HealthService.Instance.PlayerHIcons[2].enabled = false;
         }
        
    }

}

