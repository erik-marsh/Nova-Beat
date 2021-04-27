using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject imgPerfect;
    public GameObject imgA;
    public GameObject imgB;
    public GameObject imgC;
    public GameObject imgF;

    public int score;

    void Start()
    {
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

}