using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
	public static UIMgr inst;

    public GameObject perfectText;
    public GameObject greatText;
    public GameObject okayText;
    public GameObject badText;
    public GameObject terribleText;

    public Text comboText;
    public Text healthText;

    public int combo;

	private void Awake()
	{
		inst = this;
	}

	public void SetPlayerHealth(int playerHealth)
	{
        switch (playerHealth)
        {
            case 3:
                healthText.text = "OOO";
                break;
            case 2:
                healthText.text = "OO  ";
                break;
            case 1:
                healthText.text = "O    ";
                break;
            case 0:
                healthText.text = "DEAD";
                //should be dead, go to end screen, doesn't matter
                break;
            default:
                Debug.Log("UIMGR:: SetPlayerHealth called with out of bounds value");
                break;
        }
	}

    public void SetComboText(int currentCombo)
    {
        comboText.text = currentCombo.ToString();
        FinalDisplay.inst.UpdateCombo(currentCombo);
    }

    public void UpdateCombo(bool shouldIncrement)
	{
        if (shouldIncrement)
		{
            combo++;
            SetComboText(combo);
		}
        else
		{
            combo = 0;
            SetComboText(combo);
		}
	}

    public void UpdateScore(int score)
    {
        switch(score)
        {
            case 0: //perfect
                FinalDisplay.inst.numPerfects++;
                ScoresOff();
                perfectText.SetActive(true);
                break;
            case 1: //great
                FinalDisplay.inst.numGreats++;
                ScoresOff();
                greatText.SetActive(true);
                break;
            case 2: //okay
                FinalDisplay.inst.numOkays++;
                ScoresOff();
                okayText.SetActive(true);
                break;
            case 3: //bad
                FinalDisplay.inst.numBads++;
                ScoresOff();
                badText.SetActive(true);
                break;
            case 4: //terrible
                FinalDisplay.inst.numTerribles++;
                ScoresOff();
                terribleText.SetActive(true);
                break;
            default:
                Debug.Log("UIMGR:: UpdateScore called with out of bounds value");
                ScoresOff();
                break;
        }
    }

    //Turns all score's visibilities off
    public void ScoresOff()
    {
        perfectText.SetActive(false);
        greatText.SetActive(false);
        okayText.SetActive(false);
        badText.SetActive(false);
        terribleText.SetActive(false);
    }
}
