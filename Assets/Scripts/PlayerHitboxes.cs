using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxes : MonoBehaviour
{
	public static PlayerHitboxes inst;

	private void Awake()
	{
		inst = this;
	}

	public List<BoxCollider> reflectionScoreZones = new List<BoxCollider>();
	public List<BoxCollider> topScoreZones = new List<BoxCollider>();
	public List<BoxCollider> bottomScoreZones = new List<BoxCollider>();
	public BoxCollider topForwardMissZone;
	public BoxCollider topBackwardNearMissZone;
	public BoxCollider topBackwardMissZone;
	public BoxCollider bottomForwardMissZone;
	public BoxCollider bottomBackwardNearMissZone;
	public BoxCollider bottomBackwardMissZone;
	public BoxCollider reflectionForwardMissZone;
	public BoxCollider reflectionBackwardNearMissZone;
	public BoxCollider reflectionBackwardMissZone;
}
