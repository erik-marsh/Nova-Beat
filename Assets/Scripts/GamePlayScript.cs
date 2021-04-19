using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScript : MonoBehaviour
{
    public Transform enemy1;
    public Transform enemy2;

    public GameObject enemyProjectile;

    short Count = 15;
    bool LorR = false;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Count == 15 && LorR == false)
        {
            LorR = true;
            Count = 0;
            spawnProjectile(!LorR);
        }
        else if (Count == 15 && LorR == true)
        {
            LorR = false;
            Count = 0;
            spawnProjectile(!LorR);
        }
        else
        {
            Count += 1;
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
