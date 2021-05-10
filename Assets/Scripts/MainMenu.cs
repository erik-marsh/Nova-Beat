using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1Equinoxes");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2Quantum");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3Hours");
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene("Level4Flamingo");
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
        SceneManager.LoadScene("MainMenu");
    }
}
