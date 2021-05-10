using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private void Start()
	{

	}

	public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1Equinoxes");
        PlayerPrefs.SetInt("level", 1);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2Quantum");
        PlayerPrefs.SetInt("level", 2);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3Hours");
        PlayerPrefs.SetInt("level", 3);
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene("Level4Flamingo");
        PlayerPrefs.SetInt("level", 4);
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

    public void LoadMainMenu()
    {
        //Debug.Log("Main menu");
        // kill audiomgr if exists (it should) to stop sound
        GameObject audioMgr = GameObject.Find("AudioMgr");
        if (audioMgr)
		{
            Destroy(audioMgr);
		}
        SceneManager.LoadScene("MainMenu");
    }
}
