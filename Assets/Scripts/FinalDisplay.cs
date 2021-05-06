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

        //SetTestScore(); //FOR TESTING ONLY, DO NOT INCLUDE IN FINAL PROJECT

        CalculateScore();
        DisplayScore();
        DisplayGrade();
    }

    void Update()
    {

    }

    void DisplayGrade()
    {
        //chooses which image to display based on score
        if (score < 100000) //F
        {
            imgF.SetActive(true);
        }
        else if (score < 200000) //C
        {
            imgC.SetActive(true);
        }
        else if (score < 300000) //B
        {
            imgB.SetActive(true);
        }
        else if (score < 400000) //A
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