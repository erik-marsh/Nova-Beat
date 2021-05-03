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
    }

    public void displayMoveScore()
    {

    }
}
