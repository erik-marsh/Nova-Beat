﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	public int playerHealth = 3;

    public SpriteRenderer spriteRenderer;
    public Sprite[] healthSprite;

	private void Start()
	{
		// update to display initial health on UI
		UIMgr.inst.SetPlayerHealth(playerHealth);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); //attaches sprite renderer
	}

	private void Update()
	{
        
		if (playerHealth <= 0)
		{
            UIMgr.inst.scoreCounterScript.SaveScores();
            SceneManager.LoadScene("EndScreen");
		}
        else
        {
            //update sprite to match health
            //spriteRenderer.sprite = healthSprite[playerHealth - 1];
        }
        
	}

	private void OnTriggerEnter(Collider collision)
	{
		//Debug.Log("Player Collided");
		//playerHealth--;
		UIMgr.inst.SetPlayerHealth(playerHealth);
		UIMgr.inst.UpdateCombo(false);
	}
}
