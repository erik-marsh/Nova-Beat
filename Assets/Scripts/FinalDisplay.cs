using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDisplay : MonoBehaviour
{
    public static FinalDisplay inst;

    //images for final grade
    public GameObject imgPerfect;
    public GameObject imgA;
    public GameObject imgB;
    public GameObject imgC;
    public GameObject imgF;

    //variables to keep track of score
    public int numPerfects;
    public int numGreats;
    public int numOkays;
    public int numBads;
    public int numTerribles;

    public int score;

    void Start()
    {
        inst = this;

        //redundant, but just to make sure all are not displaying:
        imgPerfect.SetActive(false);
        imgA.SetActive(false);
        imgB.SetActive(false);
        imgC.SetActive(false);
        imgF.SetActive(false);

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

    }

    void DisplayStats()
    {

    }

}