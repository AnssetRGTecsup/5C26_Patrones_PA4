using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    [SerializeField] private MixerManager[] audioMixers;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
