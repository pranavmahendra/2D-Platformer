using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;

public class AcidPool : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip acidSplashClip;

    public Canvas gameOver;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>())
        {
            audioSource.clip = acidSplashClip;
            audioSource.Play();
            //activate game over canvas from here.
            gameOver.gameObject.SetActive(true);
        }
    }
}
 