using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectableLaserScript : MonoBehaviour
{
	public float reflectionToleranceY = 1.0f;
	public float reflectionToleranceX = 10.0f;

	private GameObject player;
	private Renderer rend;
	private Entity381 ent;
	private Vector3 initialVelocity;
	private Vector3 initialScale;
	private bool isFiringBack = false;
	private bool reflectMissed = true; // TODO: needs to check if you actually hit the damn thing in the first place

	private void Start()
	{
		player = EntityMgr.inst.playerEntityObject;
		rend = GetComponent<Renderer>();
		ent = GetComponent<Entity381>();
		initialVelocity = ent.velocity;
		initialScale = transform.localScale;
	}

	private void Update()
	{
		if (!isFiringBack)
		{
			Vector3 front = new Vector3(transform.position.x - rend.bounds.extents.magnitude, transform.position.y, transform.position.z);
			if (front.x <= player.transform.position.x + reflectionToleranceX
				&& front.y <= player.transform.position.y + reflectionToleranceY
				&& front.y >= player.transform.position.y - reflectionToleranceY)
			{

				if (Input.GetKey(KeyCode.Z))
				{
					if (transform.localScale.x > 1.0f)
					{
						Vector3 newScale = transform.localScale;
						newScale += new Vector3(ent.velocity.x * Time.deltaTime * 2.0f, 0, 0);
						transform.localScale = newScale;
						if (transform.localScale.x < 1.0f)
						{
							transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.z);
						}
					}
					else
					{
						// fire back
						ent.velocity = -ent.velocity;
						isFiringBack = true;
					}
				}
			}
		}
		else
		{
			if (transform.localScale.x < initialScale.x)
			{
				if (Input.GetKey(KeyCode.Z))
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
		}
	}
}
