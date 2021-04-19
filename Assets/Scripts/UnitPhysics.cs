using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPhysics : MonoBehaviour
{
	public Entity381 entity;

	private void Start()
	{
		entity.position = transform.localPosition;
	}

	private void Update()
	{
		entity.position += entity.velocity * Time.deltaTime;
		transform.localPosition = entity.position;
	}
}
