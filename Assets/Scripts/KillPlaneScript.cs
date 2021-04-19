using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneScript : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Object.Destroy(other.gameObject);
	}
}
