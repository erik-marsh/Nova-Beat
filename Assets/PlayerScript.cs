using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private void OnTriggerEnter(Collider collision)
	{
		Debug.Log("Player Collided");
		MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material.color = new Color(255, 0, 0);
	}
}
