using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerService : Monosingleton<PlayerService>
{
    public PlayerModel playerModel;
    public PlayerView playerPrefab;
    public PlayerController playerController;

    public AudioService audioService;

    public event Action EllenRun;
    public event Action EllenAttack;
    public event Action EllenHurt;
    //public event Action EllenJump;

    void Start()
    {
        CreatePlayer();

        EllenSound();

        BulletService.Instance.InitializePlayerView(this.playerController.playerView);

        AudioService.Instance.InitializePlayer(this.playerController.playerView);
        
    }

    private void Update()
    {
        
    }


    public PlayerController CreatePlayer()
    {
        PlayerModel playerModel = new PlayerModel(100);

        PlayerController playerController = new PlayerController(playerModel, playerPrefab);

        this.playerController = playerController;

        HealthService.Instance.followPlayer();

        return playerController;       
    }

    //Methods to invoke
    public void invokeRun()
    {
        EllenRun?.Invoke();
    }

    public void invokeAttack()
    {
        EllenAttack?.Invoke();
    }        

    public void invokeHurt()
    {
        EllenHurt?.Invoke();
    }

    //Sounds to be played when various events are called.
    //Run sound
    public void EllenSound()
    {
        audioService.audioSources[1].clip = audioService.playerAudioClips[0];
        audioService.audioSources[1].Play();
        audioService.audioSources[1].loop = true;
    }

}
