using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectableProjectileScript : MonoBehaviour
{
	public float reflectionToleranceY = 1.0f;
	public float reflectionToleranceX = 10.0f;

	private GameObject player;

	private void Start()
	{
		player = EntityMgr.inst.playerEntityObject;
	}

	private void Update()
	{
		if (transform.position.x <= player.transform.position.x + reflectionToleranceX
			&& transform.position.y <= player.transform.position.y + reflectionToleranceY
			&& transform.position.y >= player.transform.position.y - reflectionToleranceY)
		{
			
			//if (Input.GetKeyDown(KeyCode.Z))
			{
				var ent = GetComponent<Entity381>();
				ent.velocity.x = -ent.velocity.x;
			}
		}
	}
}
