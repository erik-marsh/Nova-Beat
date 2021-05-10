using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	public int playerHealth = 3;

    public SpriteRenderer spriteRenderer;
    public Sprite[] healthSprite;

	public float invincibilityLength = 2.0f;
	public float blinkPeriod = 0.01f;
	public float gracePeriodLength = 0.1f;

	private bool isInvincible = false;
	private bool gracePeriodEnable = false;
	private float invincibilityTimer = 0.0f;
	private float blinkTimer = 0.0f;
	private float gracePeriodTimer = 0.0f;
    private float healthRegenTimer = 0.0f;
	
	private void Start()
	{
		// update to display initial health on UI
		UIMgr.inst.SetPlayerHealth(playerHealth);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); //attaches sprite renderer
	}

	private void Update()
	{
        if (isInvincible)
		{
			// blink player sprite to show they have iframes
			blinkTimer += Time.deltaTime;
			if (blinkTimer >= blinkPeriod)
			{
				spriteRenderer.enabled = !spriteRenderer.enabled;
				blinkTimer = 0.0f;
			}

			invincibilityTimer += Time.deltaTime;
			if (invincibilityTimer >= invincibilityLength)
			{
				isInvincible = false;
				spriteRenderer.enabled = true;
			}
		}

		if (playerHealth <= 0)
		{
            UIMgr.inst.scoreCounterScript.SaveScores();
			AudioMgr.inst.FadeMusic();
            SceneManager.LoadScene("EndScreen");
		}
        else
        {
            //update sprite to match health
            //spriteRenderer.sprite = healthSprite[playerHealth - 1];
        }
        
        //regen health
        if ((healthRegenTimer <= 0) && (playerHealth < 10))
        {
            healthRegenTimer = 10.0f;

            playerHealth++;
            UIMgr.inst.SetPlayerHealth(playerHealth);
        }
        else
        {
            healthRegenTimer -= Time.deltaTime;
        }
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (isInvincible) return;

		gracePeriodTimer = 0.0f;
		gracePeriodEnable = true;


		//invincibilityTimer = 0.0f;
		//blinkTimer = 0.0f;
		//isInvincible = true;

		////Debug.Log("Player Collided");
		//playerHealth--;
		//UIMgr.inst.SetPlayerHealth(playerHealth);
		//UIMgr.inst.UpdateCombo(false);
	}

	private void OnTriggerStay(Collider other)
	{
		gracePeriodTimer += Time.deltaTime;

		if (gracePeriodEnable && gracePeriodTimer >= gracePeriodLength)
		{
			invincibilityTimer = 0.0f;
			blinkTimer = 0.0f;
			isInvincible = true;
			gracePeriodEnable = false;
            healthRegenTimer += 10.0f;

			//Debug.Log("Player Collided");
			playerHealth--;
			UIMgr.inst.SetPlayerHealth(playerHealth);
			UIMgr.inst.UpdateCombo(false);
		}
	}
}
