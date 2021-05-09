using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Debug.Log("Play game");
        SceneManager.LoadScene("Level1Equinoxes");
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
