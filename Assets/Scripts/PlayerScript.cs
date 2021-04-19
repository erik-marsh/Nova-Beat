using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	public Text hitText;
	private int numHits = 0;

	private void Update()
	{
		hitText.text = numHits.ToString();
	}

	private void OnTriggerEnter(Collider collision)
	{
		Debug.Log("Player Collided");
		numHits++;
		//MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
		//meshRenderer.material.color = new Color(255, 0, 0);
	}
}
