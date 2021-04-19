using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public GameObject projectilePrefab;
	public float spawnInterval = 2.0f;
	private float timer = 0.0f;

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= spawnInterval)
		{
			var proj = Instantiate(projectilePrefab, new Vector3(8, 0, 0), Quaternion.identity);
			proj.transform.parent = GameObject.Find("Projectiles").transform;
			timer = 0.0f;
		}
	}
}
