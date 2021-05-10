using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr inst;

    public AudioSource gamePlayMusic;

    private bool playMusicOnce = false;

    private float startSceneTime;

    private bool fadeMusic = false;
    private float initialVolume = 0.0f;

    void Awake()
    {
        inst = this;
        DontDestroyOnLoad(gameObject);
        startSceneTime = Time.time;
        gamePlayMusic.volume = PlayerPrefs.GetFloat("volume");
    }

    void Update()
    {
        if (playMusicOnce == false && Time.time - startSceneTime > 2.8f)
        //if (playMusicOnce == false)
        {
            gamePlayMusic.Play();
            playMusicOnce = true;
        }

        if (fadeMusic && gamePlayMusic.volume > 0.0f)
		{
            gamePlayMusic.volume -= (initialVolume / 2.0f) * Time.deltaTime;
		}
    }

    public void FadeMusic()
	{
        fadeMusic = true;
        initialVolume = gamePlayMusic.volume;
	}
}
