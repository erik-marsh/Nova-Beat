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
    public Image healthBar;

    public int combo;

    public ScoreCounter scoreCounterScript;

    private void Awake()
	{
		inst = this;
	}

	public void SetPlayerHealth(int playerHealth)
	{
        float value = (playerHealth / 10f);
        healthBar.fillAmount = value;
        if (healthBar.fillAmount < 0.3f)
        {
            healthBar.color = Color.red;
        }
        else if (healthBar.fillAmount < 0.6f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.green;
        }
    }

    public void SetComboText(int currentCombo)
    {
        comboText.text = currentCombo.ToString();
        scoreCounterScript.UpdateCombo(currentCombo);
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
                scoreCounterScript.numPerfects++;
                ScoresOff();
                perfectText.SetActive(true);
                break;
            case 1: //great
                scoreCounterScript.numGreats++;
                ScoresOff();
                greatText.SetActive(true);
                break;
            case 2: //okay
                scoreCounterScript.numOkays++;
                ScoresOff();
                okayText.SetActive(true);
                break;
            case 3: //bad
                scoreCounterScript.numBads++;
                ScoresOff();
                badText.SetActive(true);
                break;
            case 4: //terrible
                scoreCounterScript.numTerribles++;
                ScoresOff();
                terribleText.SetActive(true);
                break;
            case -1: // simply turns off score text
                // add miss text?
                ScoresOff();
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
