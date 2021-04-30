using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectableProjectileScript : MonoBehaviour
{
	public float reflectionToleranceY = 1.0f;
	public float reflectionMaximumX = 10.0f;
	public float reflectionMinimumX = 2.0f;

	//public float[] scoreThresholds = new float[5];
	// 0 -> perfect
	// 1 -> great
	// ... etc
	public List<BoxCollider> scoreZones = new List<BoxCollider>();

	private GameObject player;
	private Entity381 ent;
	private float distanceToTip;

	private void Start()
	{
		player = EntityMgr.inst.playerEntityObject;
		ent = GetComponent<Entity381>();
		scoreZones = ControlMgr.inst.reflectionScoreZones;
		distanceToTip = GetComponent<Renderer>().bounds.extents.magnitude;
	}

	private void Update()
	{
		//if (transform.position.x <= player.transform.position.x + reflectionMaximumX
		//	&& transform.position.x >= player.transform.position.x + reflectionMinimumX
		//	&& transform.position.y <= player.transform.position.y + reflectionToleranceY
		//	&& transform.position.y >= player.transform.position.y - reflectionToleranceY)
		//{

		//	if (Input.GetKeyDown(KeyCode.Z))
		//	{
		//		var ent = GetComponent<Entity381>();
		//		ent.velocity.x = -ent.velocity.x;
		//	}
		//}

		Vector3 projectileTip = ent.position;
		projectileTip.x -= distanceToTip;

		if (Input.GetKeyDown(KeyCode.Z))
		{
			for (int i = 0; i < scoreZones.Count; i++)
			{
				if (scoreZones[i].bounds.Contains(projectileTip))
				{
					Debug.Log("hit box " + i);
					ent.velocity.x = -ent.velocity.x;
				}
			}
		}
	}
}
