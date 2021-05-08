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

    private List<float> times = new List<float>();
    private List<bool> topIndicator = new List<bool>();
    private List<bool> reflectIndicator = new List<bool>();

    public bool createMode = false;

    private void Update()
    {
        if (createMode)
        {
            createScene();
        }
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
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentGOScale.x += 1f;
            currentGameObject.transform.localScale = currentGOScale;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentGameObject.GetComponent<Entity381>().position += new Vector3(currentGOScale.x, 0, 0);
            Vector3 tempScale = currentGameObject.transform.localScale;
            tempScale.x = tempScale.x * .95f;
            currentGameObject.transform.localScale = tempScale;
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
}
