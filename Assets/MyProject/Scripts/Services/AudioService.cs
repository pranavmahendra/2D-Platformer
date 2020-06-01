using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : Monosingleton<AudioService>
{
    public List<AudioSource> audioSources;
    public List<AudioClip> enemyAudioClips;
    public List<AudioClip> playerAudioClips;
    public List<AudioClip> backgroundClips;

    private EnemyView enemyView;
    private PlayerView playerView;

    private void Start()
    {
        audioSources[0] = gameObject.GetComponent<AudioSource>();

        PlayerService.Instance.EllenAttack += playAttackingSound;

        PlayerService.Instance.EllenDead += playAmbientDeadSound;

        PlayerService.Instance.EllenLand += playLandingSound;

        PlayerService.Instance.EllenRun += playRunningSound;

    }

    private void playRunningSound()
    {
        audioSources[1].clip = playerAudioClips[0];
        audioSources[1].Play();
        audioSources[1].loop = true;
    }

    private void playAttackingSound()
    {
        audioSources[1].clip = playerAudioClips[1];
        audioSources[1].Play();
        audioSources[1].loop = false;
    }

    public void InitializeEnemy(EnemyView enemyView)
    {
        this.enemyView = enemyView;
    }

    public void InitializePlayer(PlayerView playerView)
    {
        this.playerView = playerView;
    }


    private void playAmbientDeadSound()
    {
        audioSources[2].clip = backgroundClips[1];
        audioSources[2].Play();
    }

    private void playLandingSound()
    {
        audioSources[1].clip = playerAudioClips[4];
        audioSources[1].Play();
        audioSources[1].loop = false;
    }

    

}
