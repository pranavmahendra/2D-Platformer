using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyView : MonoBehaviour
{
    
    public KeyController keyController;

    public AudioSource audioSource;

    public bool hasPlayed = false;

    public ParticleSystem PickupEffect;

  

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
     
    }

    public void Initialize(KeyController keyController)
    {
        this.keyController = keyController;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerView>() && hasPlayed == false)
        {
            audioSource.Play();
            hasPlayed = true;
            PickupEffect.Play();
            Destroy(gameObject, 0.3f);

        }
    }

}
