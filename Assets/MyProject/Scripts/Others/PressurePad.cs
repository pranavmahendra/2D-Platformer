using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PressurePad : MonoBehaviour
{
    //Pressure pad sprites.
    public List<Sprite> padSprites;

    //Teleporter to be activated.
    public GameObject Teleporter;
 
    //Sprite renderer for pressure pad.
    private SpriteRenderer spr;

    //Hub door
    public GameObject hubDoor;
    //Hub door animator.
    private Animator hubAnimator;

    //Pressingpad sound.
    [HideInInspector]
    public bool isActivated = false;

    //Audio Source for pad.
    private AudioSource audioSource;

   
    void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();

        spr.sprite = padSprites[0];

        audioSource = gameObject.GetComponent<AudioSource>();

        hubAnimator = hubDoor.gameObject.GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerView>() && isActivated == false)
        {
            isActivated = true;

            spr.sprite = padSprites[1];

            audioSource.Play();

            HubLightsOn();


        }
    }

    public void HubLightsOn()
    {

        hubAnimator.SetBool("padPressed", isActivated);

        Teleporter.SetActive(true);

    }
}
