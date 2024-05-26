using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    AudioSource audioSource;

    void Start() 
    { 
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            audioSource.mute = !audioSource.mute;
    }
}
