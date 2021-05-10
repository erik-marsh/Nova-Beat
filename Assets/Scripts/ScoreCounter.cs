using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter inst;

    //variables to keep track of score
    public int numPerfects;
    public int numGreats;
    public int numOkays;
    public int numBads;
    public int numTerribles;

    public int maxCombo;
    public int currLevel;

    public void UpdateCombo(int combo)
    {
        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
    }

    void Start()
    {
        //all score tracking variables should be set to zero
        numPerfects = 0;
        numGreats = 0;
        numOkays = 0;
        numBads = 0;
        numTerribles = 0;

        maxCombo = 0;

        currLevel = PlayerPrefs.GetInt("level");

        //saves scores- all set to zero to start
        PlayerPrefs.SetInt("perfects", numPerfects);
        PlayerPrefs.SetInt("greats", numGreats);
        PlayerPrefs.SetInt("okays", numOkays);
        PlayerPrefs.SetInt("bads", numBads);
        PlayerPrefs.SetInt("terribles", numTerribles);

        PlayerPrefs.SetInt("maxCombo", maxCombo);
        PlayerPrefs.SetInt("playedLevel", currLevel);
    }

    public void SaveScores()
    {
        //saves scores
        PlayerPrefs.SetInt("perfects", numPerfects);
        PlayerPrefs.SetInt("greats", numGreats);
        PlayerPrefs.SetInt("okays", numOkays);
        PlayerPrefs.SetInt("bads", numBads);
        PlayerPrefs.SetInt("terribles", numTerribles);

        PlayerPrefs.SetInt("maxCombo", maxCombo);
        PlayerPrefs.SetInt("playedLevel", currLevel);
    }

}
