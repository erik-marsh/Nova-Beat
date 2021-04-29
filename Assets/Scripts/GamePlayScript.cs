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

    public bool createMode = false;

    private int currentBeat = 0;
    private float currentTime = 0f;

    private void Update()
    {
        if (createMode)
        {
            createScene();
        }


        //if (Time.realtimeSinceStartup > times[currentBeat] + 5.0f - 1.7f)
        //{
        //    Debug.Log(topIndicator[currentBeat]);
        //    spawnProjectile(!topIndicator[currentBeat], reflectIndicator[currentBeat]);

        //    currentBeat++;
        //}
    }

    private bool projectileCreating = false;
    private GameObject currentGameObject;
    private Vector3 currentGOScale = Vector3.one;
    private bool projectileCreating2 = false;
    private GameObject currentGameObject2;
    private Vector3 currentGOScale2 = Vector3.one;
    private Vector3 currentGOTransform = Vector3.one;
    private Vector3 currentGOTransform2 = Vector3.one;
    private bool zPressed = false;
    private void createScene()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            zPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            zPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (projectileCreating == false)
            {
                projectileCreating = true;
                if (zPressed)
                    currentGameObject = Instantiate(refectableProjectile, enemy1);
                else
                    currentGameObject = Instantiate(enemyProjectile, enemy1);
                currentGOTransform = currentGameObject.transform.position;
            }
            //Spawn a projectile if it is not already creating one
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentGOScale.x += 1f;
            currentGameObject.transform.localScale = currentGOScale;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentGameObject.GetComponent<Entity381>().position += new Vector3(currentGOScale.x, 0, 0);
            currentGOScale = Vector3.one;
            projectileCreating = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (projectileCreating2 == false)
            {
                projectileCreating2 = true;
                if (zPressed)
                    currentGameObject2 = Instantiate(refectableProjectile, enemy2);
                else
                    currentGameObject2 = Instantiate(enemyProjectile, enemy2);
                currentGOTransform2 = currentGameObject2.transform.position;
            }
            //Spawn a projectile if it is not already creating one
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentGOScale2.x += 1f;
            currentGameObject2.transform.localScale = currentGOScale2;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            currentGameObject2.GetComponent<Entity381>().position += new Vector3(currentGOScale2.x, 0, 0);
            currentGOScale2 = Vector3.one;
            projectileCreating2 = false;
        }

    }

    private void spawnProjectile(bool topLane, bool reflectable)
    {
        if (topLane)
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
