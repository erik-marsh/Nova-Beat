using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonReflectableProjectileScript : MonoBehaviour
{
	public Vector3 projectileTip;

	private Entity381 ent;
	private Renderer rend;
	private List<BoxCollider> topScoreZones;
	private List<BoxCollider> bottomScoreZones;
	private BoxCollider topMissZone;
	private BoxCollider bottomMissZone;

	private bool stopCheckingHitreg = false;

	private void Awake()
	{
		ent = GetComponent<Entity381>();
		rend = GetComponent<Renderer>();
		projectileTip = new Vector3();
	}

	private void Start()
	{
		topScoreZones = ControlMgr.inst.topScoreZones;
		bottomScoreZones = ControlMgr.inst.bottomScoreZones;
		topMissZone = ControlMgr.inst.topMissZone;
		bottomMissZone = ControlMgr.inst.bottomMissZone;
	}

	private void Update()
	{
		projectileTip = ent.position;
		projectileTip.x -= rend.bounds.extents.magnitude;
	}

	// note the LateUpdate, this ensures the ship has moved before testing the top/bottom hitboxes
	// if the order of calls to Update was well-defined, we could use the reflectionScoreZones
	private void LateUpdate()
	{
		if (stopCheckingHitreg) return;

		// test if moving up should give score
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//Debug.Log("uparrow");
			for (int i = 0; i < bottomScoreZones.Count; i++)
			{
				if (bottomMissZone.bounds.Contains(projectileTip))
				{
					stopCheckingHitreg = true;
					UIMgr.inst.UpdateCombo(false);
					return;
				}

				if (bottomScoreZones[i].bounds.Contains(projectileTip))
				{
					UIMgr.inst.UpdateScore(i);
					UIMgr.inst.UpdateCombo(true);
					Debug.Log("Score update on bottomScoreZone " + i);
					stopCheckingHitreg = true;
					return;
				}
			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			//Debug.Log("downarrow");
			for (int i = 0; i < topScoreZones.Count; i++)
			{
				if (topMissZone.bounds.Contains(projectileTip))
				{
					stopCheckingHitreg = true;
					UIMgr.inst.UpdateCombo(false);
					return;
				}

				if (topScoreZones[i].bounds.Contains(projectileTip))
				{
					UIMgr.inst.UpdateScore(i);
					UIMgr.inst.UpdateCombo(true);
					Debug.Log("Score update on topScoreZone " + i);
					stopCheckingHitreg = true;
					return;
				}
			}
		}
	}
}
