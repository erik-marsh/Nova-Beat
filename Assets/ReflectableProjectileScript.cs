using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectableProjectileScript : MonoBehaviour
{
	public float reflectionRadius = 5.0f;

	private GameObject player;

	private void Awake()
	{
		player = EntityMgr.inst.playerEntityObject;
	}

	private void Update()
	{
		if (Vector3.Distance(player.transform.position, transform.position) <= reflectionRadius)
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				var ent = GetComponent<Entity381>();
				ent.velocity.x = -ent.velocity.x;
			}
		}
	}
}
