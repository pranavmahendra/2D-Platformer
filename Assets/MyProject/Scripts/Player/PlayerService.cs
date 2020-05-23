using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : Monosingleton<PlayerService>
{
    public PlayerModel playerModel;
    public PlayerView playerPrefab;
    public PlayerController playerController;


    void Start()
    {
        CreatePlayer();
    }

    public PlayerController CreatePlayer()
    {
        PlayerModel playerModel = new PlayerModel(100);

        PlayerController playerController = new PlayerController(playerModel, playerPrefab);

        this.playerController = playerController;

        return playerController;       
    }

  
}
