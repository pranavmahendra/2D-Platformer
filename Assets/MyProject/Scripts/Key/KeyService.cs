using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyService : Monosingleton<KeyService>
{
    public KeyView KeyView;
    private KeyModel keyModel;
    public KeyController keyController;

    private void Start()
    {
        //CreateNewKey();
        
            
    }

    private void Update()
    {
        
    }

    //public KeyController CreateNewKey()
    //{
    //    keyModel = new KeyModel(20);

    //    KeyController keyController = new KeyController(keyModel, KeyView);

    //    this.keyController = keyController;

    //    return keyController;
    //}
}
