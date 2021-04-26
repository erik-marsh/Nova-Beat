using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GamePlayScript : MonoBehaviour
{
    public Transform enemy1;
    public Transform enemy2;

    public GameObject enemyProjectile;
    public GameObject refectableProjectile;
    short Count = 15;
    bool LorR = false;

    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public float songLengthInSec = 170;
    private int measureCount;
    public int bpm = 160;
    private float measuresPerSec;

    private void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;

        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        measureCount =  1 + (int) songLengthInSec * bpm / 60 / 4;
        //measuresPerSec = measureCount /songLengthInSec;
        //measuresPerSec *= 2f;
        measuresPerSec = 1.888f;
        Debug.Log(measureCount);
        Debug.Log(measuresPerSec);

    }

    private int currentMeasure = 0;

    private void Update()
    {
        if (Time.realtimeSinceStartup > currentMeasure * measuresPerSec + 5.0f)
        {
            currentMeasure++;
            Debug.Log("Fire");
        }
    }

    private void spawnProjectile(bool enemyShip1)
    {
        if (enemyShip1)
        {
            Instantiate(enemyProjectile, enemy1);
        }
        else
        {
            Instantiate(enemyProjectile, enemy2);
        }
    }
}
