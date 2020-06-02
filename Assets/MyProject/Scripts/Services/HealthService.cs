using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthService : Monosingleton<HealthService>
{
    public PlayerView playerView;
    //Hearts at the top
    public List<Animator>  HealthAnims;

    
    void Start()
    {
        
        foreach (Animator item in HealthAnims)
        {
           item.gameObject.GetComponent<Animator>();
        }

    }


    public void followPlayer()
    {
        playerView = PlayerService.Instance.playerController.playerView;
    }
}
