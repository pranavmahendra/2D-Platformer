using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletController
{

   public BulletController(BulletModel bulletModel, BulletView BulletPrefab)
    {
        BulletModel = bulletModel;

        BulletPrefab = GameObject.Instantiate<BulletView>(BulletPrefab);

        this.BulletView = BulletPrefab;

        BulletView.Initialize(this);

    }

    public BulletModel BulletModel { get; }
    public BulletView BulletView { get; }

    //public event Action EllenBulletDes;

    public void setPosition(Vector3 bulletPos, Quaternion bulletRotation)
    {
        BulletView.transform.position = bulletPos;
        BulletView.transform.rotation = bulletRotation;
    }

    //Movement of Bullet
    public void BulletMovement()
    {
        BulletView.rb2d.velocity = BulletView.transform.right * BulletModel.Speed * Time.deltaTime;
    }

    public void DestroyLogic()
    {
        BulletView.Destroy(BulletView.gameObject, 3f);
    }

}
