using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : Monosingleton<BulletService>
{
    public List<BulletView> BulletPrefabs;

    public BulletController bulletController;
    public PlayerView playerView;

    private void Start()
    {
     
    }

    public void InitializePlayerView(PlayerView playerView)
    {
        this.playerView = playerView;
    }

    public BulletController CreateEllenBullet()
    {
        BulletModel bulletModel = new BulletModel(30,500);

        BulletController bulletController = new BulletController(bulletModel, BulletPrefabs[0]);

        this.bulletController = bulletController;

        BulletMuzzle();
     
        return bulletController;
    }

    //Bullet Explode
    public void BulletMuzzle()
    {
        VFXService.Instance.CreateMuzzleFlash(playerView.tipPosition.position,playerView.tipPosition.rotation);
    }


}
