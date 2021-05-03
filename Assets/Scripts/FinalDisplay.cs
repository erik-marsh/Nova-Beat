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
    public int numPerfects;
    public int numGreats;
    public int numOkays;
    public int numBads;
    public int numTerribles;

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

        //all score tracking variables should be set to zero
        numPerfects = 0;
        numGreats = 0;
        numOkays = 0;
        numBads = 0;
        numTerribles = 0;
        score = 0;
        maxCombo = 0;

        //SetTestScore(); //FOR TESTING ONLY, DO NOT INCLUDE IN FINAL PROJECT

        CalculateScore();
        DisplayScore();
        DisplayGrade();
    }

    void Update()
    {

    }

    public void UpdateCombo(int combo)
    {
        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
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
        score += numPerfects * 500;
        score += numGreats * 350;
        score += numOkays * 200;
        score += numBads * 100;
        //Terribles do not give points
    }

    void DisplayScore()
    {
        scoreText.text = score.ToString();
        maxComboText.text = maxCombo.ToString();

        perfectText.text = numPerfects.ToString();
        greatText.text = numGreats.ToString();
        okayText.text = numOkays.ToString();
        badText.text = numBads.ToString();
        terribleText.text = numTerribles.ToString();
    }

    void SetTestScore()
    {
        numPerfects = 100;
        numGreats = 30;
        numBads = 3;
    }

}