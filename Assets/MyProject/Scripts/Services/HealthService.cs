using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthService : Monosingleton<HealthService>
{
    public PlayerView playerView;
    public List<Image> PlayerHIcons;

    
    void Start()
    {
        
        foreach (Image item in PlayerHIcons)
        {
           item.gameObject.GetComponent<Image>();
        }

       

    }

    private void FixedUpdate()
    {
        HideHeart1(); HideHeart2(); HideHeart3(); HideHeart4();
    }

    public void HideHeart1()
    {

        if (playerView.getHealh() < 75)
        {
            PlayerHIcons[0].enabled = false;
        }
    }

    public void HideHeart2()
    {

        if (playerView.getHealh() < 50)
        {
            PlayerHIcons[1].enabled = false;
        }
    }

    public void HideHeart3()
    {

        if (playerView.getHealh() < 25)
        {
            PlayerHIcons[2].enabled = false;
        }
    }

    public void HideHeart4()
    {

        if (playerView.getHealh() == 0)
        {
            PlayerHIcons[3].enabled = false;
        }
    }




    public void followPlayer()
    {
        playerView = PlayerService.Instance.playerController.playerView;
    }
}
