using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerFollow : Monosingleton<CamerFollow>
{
    //PLayerview
    //game object

    public CinemachineVirtualCamera vcam;
    public PlayerView playerView;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

   
    void Update()
    {
        vcam.Follow = playerView.transform;
        vcam.LookAt = playerView.transform;
    }

    public void followPlayer()
    {
        playerView = PlayerService.Instance.playerController.playerView;
    }
}
