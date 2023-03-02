using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus 
{       
    public static Action<GameObject,int> hit;

    public static void GetHit(GameObject gameObject,int value)
    {
        hit?.Invoke(gameObject,value);
    }
}
