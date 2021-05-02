using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	public int playerHealth = 3;

	private void Start()
	{
		// update to display initial health on UI
		// UIMgr.inst.SetPlayerHealth(playerHealth)
	}

	private void Update()
	{
		if (playerHealth <= 0)
		{
			// kill player, enter game over screen
		}
	}

	private void OnTriggerEnter(Collider collision)
	{
		Debug.Log("Player Collided");
		playerHealth--;
		// UIMgr.inst.SetPlayerHealth(playerHealth)
	}
}
