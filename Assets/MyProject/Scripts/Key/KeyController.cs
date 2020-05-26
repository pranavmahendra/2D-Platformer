using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController
{
    public KeyController(KeyModel keyModel, KeyView prefab)
    {
        KeyModel = keyModel;

        prefab = GameObject.Instantiate<KeyView>(prefab);

        this.keyView = prefab;

        keyView.Initialize(this);
        
    }

    public KeyModel KeyModel { get; }
    public KeyView keyView { get; }
}
