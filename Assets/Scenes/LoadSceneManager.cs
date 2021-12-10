using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LoadSceneManager : Singleton<LoadSceneManager>
{
    public event Action OnLoadStart = delegate { };
    public event Action OnLoadEnd = delegate { };

    void Start()
    {
        OnLoadStart();
        OnLoadEnd();

    }
}
