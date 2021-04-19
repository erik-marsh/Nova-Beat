using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public AudioSource gamePlayMusic;

    private bool playMusicOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playMusicOnce == false && Time.time > 1f)
        {
            gamePlayMusic.Play();
            playMusicOnce = true;
        }
    }
}
