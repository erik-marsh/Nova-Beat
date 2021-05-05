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
	private List<BoxCollider> topMissZones;
	private List<BoxCollider> bottomMissZones;
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
		//topForwardMissZone = ControlMgr.inst.topForwardMissZone;
		//bottomForwardMissZone = ControlMgr.inst.bottomForwardMissZone;
		topMissZones = new List<BoxCollider>();
		topMissZones.Add(ControlMgr.inst.topForwardMissZone);
		topMissZones.Add(ControlMgr.inst.topBackwardNearMissZone);
		topMissZones.Add(ControlMgr.inst.topBackwardMissZone);
		
		bottomMissZones = new List<BoxCollider>();
		bottomMissZones.Add(ControlMgr.inst.bottomForwardMissZone);
		bottomMissZones.Add(ControlMgr.inst.bottomBackwardNearMissZone);
		bottomMissZones.Add(ControlMgr.inst.bottomBackwardMissZone);
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
			for (int i = 0; i < bottomMissZones.Count; i++)
			{
				if (bottomMissZones[i].bounds.Contains(projectileTip))
				{
					stopCheckingHitreg = true;
					UIMgr.inst.UpdateScore(-1);
					UIMgr.inst.UpdateCombo(false);
					Debug.Log("Player missed at bottom miss zone " + i);
					return;
				}
			}

			for (int i = 0; i < bottomScoreZones.Count; i++)
			{
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
			for (int i = 0; i < topMissZones.Count; i++)
			{
				if (topMissZones[i].bounds.Contains(projectileTip))
				{
					stopCheckingHitreg = true;
					UIMgr.inst.UpdateScore(-1);
					UIMgr.inst.UpdateCombo(false);
					Debug.Log("Player missed at top miss zone " + i);
					return;
				}
			}

			for (int i = 0; i < topScoreZones.Count; i++)
			{
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
