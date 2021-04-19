using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr : MonoBehaviour
{
	public static EntityMgr inst;
	private void Awake()
	{
		inst = this;
	}

	public List<Entity381> enemyEntities;
	public GameObject playerEntityObject;
}
