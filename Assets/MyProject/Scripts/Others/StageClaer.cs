using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class StageClaer : MonoBehaviour
{
    //Particles respawn.
    public ParticleSystem respawn;

    public Canvas gameOverCanvas;

    //AudioSource for teleporter.
    public AudioSource audioSource;

    public AudioClip audioClip;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>())
        {
            VFXService.Instance.CreateRespawn(this.transform.position, this.transform.rotation);

            audioSource.clip = audioClip;
            audioSource.Play();
            audioSource.loop = false;
            audioSource.volume = 0.3f;

            StartCoroutine(canvasActivate());

            PlayerService.Instance.playerController.playerView.gameObject.SetActive(false);
        }
    }

    IEnumerator canvasActivate()
    {
        yield return new WaitForSeconds(3);
        gameOverCanvas.gameObject.SetActive(true);
    }
}
