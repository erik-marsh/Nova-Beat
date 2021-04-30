using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectableLaserScript : MonoBehaviour
{
	public List<BoxCollider> scoreZones = new List<BoxCollider>();

	private Renderer rend;
	private Entity381 ent;
	private Vector3 initialScale;
	private bool isFiringBack = false;
	private bool initialHitRegistered = false;

	private void Start()
	{
		scoreZones = ControlMgr.inst.reflectionScoreZones;
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
				for (int i = 0; i < scoreZones.Count; i++)
				{
					if (Input.GetKeyDown(KeyCode.Z) && scoreZones[i].bounds.Contains(projectileTip))
					{
						Debug.Log("hit box " + i);
						initialHitRegistered = true;
					}
				}
			}
			else
			{
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
							// TODO: this is where you would update score
							Debug.Log("Score update");
							ent.velocity = -ent.velocity;
							isFiringBack = true;
						}
					}
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
