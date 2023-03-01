using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus 
{       
    public static Action<GameObject> hit;

    public static void GetHit(GameObject gameObject)
    {
        hit?.Invoke(gameObject);
    }
}
