using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlay : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        this.GetComponent<AudioSource>().Play();    
    }
}
