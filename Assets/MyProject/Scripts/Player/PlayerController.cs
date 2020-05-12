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
    public bool isCrouching;
 

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
        playerView.transform.localScale = scale;
        
        
        if(isCrouching == false)
        {
             playerView.transform.Translate(Vector3.right * speed * 2 * Time.deltaTime);
        }
    }

    //Jump Logic
    public void playerJump()
    {
 
        if(Input.GetKey(KeyCode.Space) && isCrouching == false)
        {
            isJumping = true;
            playerView.rb2d.AddForce(new Vector2(0f, playerView.jumpForce), ForceMode2D.Force);
            playerView.transform.Translate(Vector3.up * 4f * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
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

    
    
}

