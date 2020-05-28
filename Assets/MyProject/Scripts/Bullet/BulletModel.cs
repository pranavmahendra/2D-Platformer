using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
   public BulletModel(int damage,int speed)
    {
        Damage = damage;
        Speed = speed;
    }

    public int Damage { get; }
    public int Speed { get; }
}
