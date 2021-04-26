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
    private List<float> times = new List<float>();
    private List<bool> topIndicator = new List<bool>();
    private List<bool> reflectIndicator = new List<bool>();


    private void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;

        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        measureCount =  1 + (int) songLengthInSec * bpm / 60 / 4;
        //measuresPerSec = measureCount /songLengthInSec;
        //measuresPerSec *= 2f;
        measuresPerSec = 1.888f;
        foreach(string line in eachLine)
        {
            int posTab0 = 0;
            int posTab1 = 1;
            int currentIndex = 0;
            foreach (char c in line)
            {
                if (c == '\t')
                {
                    if (posTab0 == 0)
                    {
                        posTab0 = currentIndex;
                    }
                    else
                    {
                        posTab1 = currentIndex;
                    }
                }
                currentIndex++;
            }
            var test = line.Split("\t"[0]);
            
            times.Add(float.Parse(test[0])); //from 0 to 0 to postab -1

            if (line[posTab1 + 1] == '0')
            {
                topIndicator.Add(false);
            }
            else
            {
                topIndicator.Add(true);
            }
            if (line[posTab0 + 1] == '0')
            {
                reflectIndicator.Add(false);
            }
            else
            {
                reflectIndicator.Add(true);
            }
        }
    }

    private int currentBeat = 0;
    private float currentTime = 0f;

    private void Update()
    {
        
        if (Time.realtimeSinceStartup > times[currentBeat] + 5.0f - 1.7f)
        {
            Debug.Log(topIndicator[currentBeat]);
            spawnProjectile(!topIndicator[currentBeat], reflectIndicator[currentBeat]);

            currentBeat++;
        }
    }

    private void spawnProjectile(bool enemyShip1, bool reflectable)
    {
        if (enemyShip1)
        {
            if (reflectable)
                Instantiate(refectableProjectile, enemy1);
            else
                Instantiate(enemyProjectile, enemy1);
        }
        else
        {
            if (reflectable)
                Instantiate(refectableProjectile, enemy2);
            else
                Instantiate(enemyProjectile, enemy2);
        }
    }
}
