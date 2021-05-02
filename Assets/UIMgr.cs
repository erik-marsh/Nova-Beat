using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
	public static UIMgr inst;

	private void Awake()
	{
		inst = this;
	}

	public void SetPlayerHealth(int playerHealth)
	{
		
	}
}
