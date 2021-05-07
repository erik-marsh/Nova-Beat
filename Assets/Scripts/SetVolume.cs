using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public float savedVol = 1;

    void Awake()
    {
        PlayerPrefs.SetFloat("volume", 1);
    }

    public void SaveVolume(float setVolume)
    {
        savedVol = setVolume;
        PlayerPrefs.SetFloat("volume", savedVol);
    }
}
