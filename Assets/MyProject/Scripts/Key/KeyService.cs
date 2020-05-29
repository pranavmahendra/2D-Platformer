using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyService : Monosingleton<KeyService>
{
    public KeyView KeyView;
    private KeyModel keyModel;
    public KeyController keyController;

    //Action on key collection.
    public event Action KeyCollected;

    private void Start()
    {
        
   
        AchievementSystem.Instance.InitializeKey(KeyView);


    }

    public void KeyActionInvoke()
    {
        KeyCollected?.Invoke();
    }
}
