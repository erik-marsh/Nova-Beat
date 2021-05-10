using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDisplay : MonoBehaviour
{
    public static FinalDisplay inst;

    //images for final grade
    public GameObject imgPerfect;
    public GameObject imgA;
    public GameObject imgB;
    public GameObject imgC;
    public GameObject imgF;

    //text elements for showing score
    public Text scoreText;
    public Text maxComboText;

    public Text perfectText;
    public Text greatText;
    public Text okayText;
    public Text badText;
    public Text terribleText;

    //variables to keep track of score
    public int finalPerfects;
    public int finalGreats;
    public int finalOkays;
    public int finalBads;
    public int finalTerribles;

    public int score;
    public int maxCombo;

    public int playedLevel; //holds level info
    public int maxHits; //used to calculate scores, holds number of lazers in song

    void Start()
    {
        inst = this;

        //redundant, but just to make sure all are not displaying:
        imgPerfect.SetActive(false);
        imgA.SetActive(false);
        imgB.SetActive(false);
        imgC.SetActive(false);
        imgF.SetActive(false);

        //load all score variables
        finalPerfects = PlayerPrefs.GetInt("perfects");
        finalGreats = PlayerPrefs.GetInt("greats");
        finalOkays = PlayerPrefs.GetInt("okays");
        finalBads = PlayerPrefs.GetInt("bads");
        finalTerribles = PlayerPrefs.GetInt("terribles");
        score = 0; //will be calculated here
        maxCombo = PlayerPrefs.GetInt("maxCombo");

        playedLevel = PlayerPrefs.GetInt("playedLevel");

        //SetTestScore(); //FOR TESTING ONLY, DO NOT INCLUDE IN FINAL PROJECT

        SetHits();
        CalculateScore();
        DisplayScore();
        DisplayGrade();
    }

    void Update()
    {

    }

    void SetHits()
    {
        switch(playedLevel)
        {
            case 1:
                maxHits = 187;
                break;
            case 2:
                maxHits = 167;
                break;
            case 3:
                maxHits = 105;
                break;
            case 4:
                maxHits = 220;
                break;
        }
    }

    void DisplayGrade()
    {
        //chooses which image to display based on score
        // F - < 50%
        // C - 50%+ were Perfect or better
        // B - 75%+ were Perfect or better
        // A - 90%+ were Perfect or better
        // Perfect - 100%
        if (score < (maxHits * 250)) //F
        {
            imgF.SetActive(true);
        }
        else if (score < (maxHits * 375)) //C
        {
            imgC.SetActive(true);
        }
        else if (score < (maxHits * 450)) //B
        {
            imgB.SetActive(true);
        }
        else if (score < (maxHits * 500)) //A
        {
            imgA.SetActive(true);
        }
        else //Perfect
        {
            imgPerfect.SetActive(true);
        }
    }

    void CalculateScore()
    {
        score += finalPerfects * 500;
        score += finalGreats * 350;
        score += finalOkays * 200;
        score += finalBads * 100;
        //Terribles do not give points
    }

    void DisplayScore()
    {
        scoreText.text = score.ToString();
        maxComboText.text = maxCombo.ToString();

        perfectText.text = finalPerfects.ToString();
        greatText.text = finalGreats.ToString();
        okayText.text = finalOkays.ToString();
        badText.text = finalBads.ToString();
        terribleText.text = finalTerribles.ToString();
    }

    void SetTestScore()
    {
        finalPerfects = 100;
        finalGreats = 30;
        finalBads = 3;
    }

}