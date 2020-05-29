using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AchievementSystem : Monosingleton<AchievementSystem>
{

    private KeyView keyView;

    //Data to store keys collected value.
    private int KeysCollected = 0;

    public TextMeshProUGUI KeysCollectedGUI;
    
    private bool isCollected = false;

    public Animator keyAnim;

    private void Start()
    {
        KeyService.Instance.KeyCollected += keyCollect;
    }


    //Key Collection Functions
    private void keyCollect()
    {
        if(isCollected == false)
        {
            KeysCollected += 1;
            keyAnim.gameObject.SetActive(true);
            isCollected = true;
            keyAnim.SetBool("KeyCollected", isCollected);
            Invoke("SetBoolBack", 0.5f);
            //Increase keys when keys collected by the player.
            KeysCollectedGUI.text = "Keys Collected: " + KeysCollected;
        }
    }

    //Set everything back to false.
    private void SetBoolBack()
    {
        if(isCollected == true)
        {
            isCollected = false;
            keyAnim.gameObject.SetActive(false);
            keyAnim.SetBool("KeyCollected", isCollected);
        }
      
    }

   
    //Initializing Player View
    public void InitializeKey(KeyView keyView)
    {
        this.keyView = keyView;
    }
}
