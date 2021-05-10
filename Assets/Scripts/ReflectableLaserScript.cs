using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectableLaserScript : MonoBehaviour
{
	public List<BoxCollider> scoreZones = new List<BoxCollider>();
	public List<BoxCollider> missZones = new List<BoxCollider>();

	private Renderer rend;
	private Entity381 ent;
	private Vector3 initialScale;
	private bool isFiringBack = false;
	private bool initialHitRegistered = false;

	private void Start()
	{
		scoreZones = ControlMgr.inst.reflectionScoreZones;
		missZones.Add(ControlMgr.inst.reflectionForwardMissZone);
		missZones.Add(ControlMgr.inst.reflectionBackwardNearMissZone);
		missZones.Add(ControlMgr.inst.reflectionBackwardMissZone);

		rend = GetComponent<Renderer>();
		ent = GetComponent<Entity381>();
		initialScale = transform.localScale;
	}
	 
	
	private void Update()
	{
		if (!isFiringBack)
		{
			Vector3 projectileTip = ent.position;
			projectileTip.x -= rend.bounds.extents.magnitude;

			if (!initialHitRegistered)
			{
				for (int i = 0; i < missZones.Count; i++)
				{
					if (Input.GetKeyDown(KeyCode.Z) && missZones[i].bounds.Contains(projectileTip))
					{
						if (i == 1)
						{
							initialHitRegistered = true;
						}
						else
						{
							UIMgr.inst.UpdateScore(-1);
							UIMgr.inst.UpdateCombo(false);
						}
					}
				}

				for (int i = 0; i < scoreZones.Count; i++)
				{
					if (Input.GetKeyDown(KeyCode.Z) && scoreZones[i].bounds.Contains(projectileTip))
					{
						//Debug.Log("hit box " + i);
						initialHitRegistered = true;
					}
				}
			}
			else
			{
				if (Input.GetKeyDown(KeyCode.Z) && missZones[1].bounds.Contains(projectileTip))
				{
					if (transform.localScale.x > 1.0f)
					{
						ShrinkProjectile();
					}
					else
					{
						// fire back
						UIMgr.inst.UpdateScore(1);
						UIMgr.inst.UpdateCombo(true);
						//Debug.Log("Score update");
						ent.velocity = -ent.velocity;
						ent.position.y = 1.76f;
						isFiringBack = true;
					}
				}

				for (int i = 0; i < scoreZones.Count; i++)
				{
					if (Input.GetKey(KeyCode.Z) && scoreZones[i].bounds.Contains(projectileTip))
					{
						if (transform.localScale.x > 1.0f)
						{
							ShrinkProjectile();
						}
						else
						{
							// fire back
							UIMgr.inst.UpdateScore(i);
							UIMgr.inst.UpdateCombo(true);
							//Debug.Log("Score update");
							ent.velocity = -ent.velocity;
							ent.position.y = 1.76f;
							isFiringBack = true;
						}
					}

					// check miss zones
				}
			}
		}
		else
		{
			if (transform.localScale.x < initialScale.x)
			{
				GrowProjectile();
			}
		}
	}

	void ShrinkProjectile()
	{
		Vector3 newScale = transform.localScale;
		newScale += new Vector3(ent.velocity.x * Time.deltaTime * 2.0f, 0, 0);
		transform.localScale = newScale;
		if (transform.localScale.x < 1.0f)
		{
			transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.z);
		}
	}

	void GrowProjectile()
	{
		Vector3 newScale = transform.localScale;
		newScale += new Vector3(ent.velocity.x * Time.deltaTime * 2.0f, 0, 0);
		transform.localScale = newScale;
		if (transform.localScale.x > initialScale.x)
		{
			transform.localScale = initialScale;
		}
	}	
}
