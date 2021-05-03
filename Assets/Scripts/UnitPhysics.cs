using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPhysics : MonoBehaviour
{
	public Entity381 entity;

	private void Start()
	{
		entity.position = transform.position;
	}

	private void Update()
	{
		entity.position += entity.velocity * Time.deltaTime;
		transform.position = entity.position;
	}
}
