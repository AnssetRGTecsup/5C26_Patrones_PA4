using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{
    public static event Action<string> OnBunnyDead;

    public static void BunnyDead(string message)
    {
        if(OnBunnyDead != null)
        {
            OnBunnyDead(message);
            Debug.Log(message + "1");
        }
    }
}
