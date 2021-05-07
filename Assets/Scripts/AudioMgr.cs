using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public AudioSource gamePlayMusic;

    private bool playMusicOnce = false;

    private float startSceneTime;

    // Start is called before the first frame update
    void Awake()
    {
        startSceneTime = Time.time;
        gamePlayMusic.volume = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        if (playMusicOnce == false && Time.time - startSceneTime > 2.8f)
        //if (playMusicOnce == false)
        {
            gamePlayMusic.Play();
            playMusicOnce = true;
        }
    }
}
