using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectableProjectileScript : MonoBehaviour
{
	//public float[] scoreThresholds = new float[5];
	// 0 -> perfect
	// 1 -> great
	// ... etc
	public List<BoxCollider> scoreZones = new List<BoxCollider>();

	private Entity381 ent;
	private float distanceToTip;

	private void Start()
	{
		ent = GetComponent<Entity381>();
		scoreZones = ControlMgr.inst.reflectionScoreZones;
		distanceToTip = GetComponent<Renderer>().bounds.extents.magnitude;
	}

	private void Update()
	{
		Vector3 projectileTip = ent.position;
		projectileTip.x -= distanceToTip;

		if (Input.GetKeyDown(KeyCode.Z))
		{
			for (int i = 0; i < scoreZones.Count; i++)
			{
				if (scoreZones[i].bounds.Contains(projectileTip))
				{
					UIMgr.inst.UpdateScore(i);
					Debug.Log("hit box " + i);
					ent.velocity.x = -ent.velocity.x;
				}
			}
		}
	}
}
