﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXService : Monosingleton<VFXService>
{
    public ParticleSystem[] particles;

    public void CreatePoison(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Instantiate(particles[0], spawnPosition, spawnRotation);
        particles[0].Play();
    }

    public void CreateBulletExplosion(Vector3 spawnPosition, Quaternion rotation)
    {
        Instantiate(particles[1], spawnPosition, rotation);
        particles[1].Play();
    }

    public void CreateMuzzleFlash(Vector3 spawnPosition, Quaternion rotation)
    {
        Instantiate(particles[2], spawnPosition, rotation);
        particles[2].Play();
    }

    public void CreateRespawn(Vector3 spawnPos, Quaternion rotation)
    {
        Instantiate(particles[3], spawnPos, rotation);
        particles[3].Play();
    }

    public void EllenHurt(Vector3 spawnPos, Quaternion rot)
    {
        Instantiate(particles[4], spawnPos, rot);
        particles[4].Play();
    }

}
