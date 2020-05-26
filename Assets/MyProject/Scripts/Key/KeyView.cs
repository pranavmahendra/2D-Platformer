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

    //public event Action KeyPickup;

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

           
            Instantiate(PickupEffect, this.transform.position, this.transform.rotation);
            PickupEffect.Play();
            //KeyPickup?.Invoke();
            //this.gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() && hasPlayed == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}
