using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
	public static UIMgr inst;

    public GameObject perfectText;
    public GameObject greatText;
    public GameObject okayText;
    public GameObject badText;
    public GameObject terribleText;

    public GameObject comboText;
    public GameObject healthText;

	private void Awake()
	{
		inst = this;
	}

	public void SetPlayerHealth(int playerHealth)
	{
		
	}
}
