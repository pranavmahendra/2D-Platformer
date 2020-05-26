using System.Collections;
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
}
