using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenProjectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("EndScreenProjectile hit");
        UIMgr.inst.scoreCounterScript.SaveScores();
        SceneManager.LoadScene("EndScreen");
    }
}
