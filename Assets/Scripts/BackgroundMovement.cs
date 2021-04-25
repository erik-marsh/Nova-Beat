using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
	public static BackgroundMovement inst;

	public float movementRate = 1.0f;
	public float parallaxSmoothing = 1.0f;
	public List<Transform> backgrounds;

	private List<float> parallaxScales;

	private void Awake()
	{
		inst = this;
	}

	private void Start()
	{
		parallaxScales = new List<float>();
		for (int i = 0; i < backgrounds.Count; i++)
		{
			parallaxScales.Add(backgrounds[i].position.z * -1.0f);
		}
	}

	private void Update()
	{
		for (int i = 0; i < backgrounds.Count; i++)
		{
			Transform t = backgrounds[i];
			Vector3 backgroundTargetPosition = new Vector3(
				t.position.x + (movementRate * Time.deltaTime * parallaxScales[i]),
				t.position.y,
				t.position.z
			);
			t.position = Vector3.Lerp(t.position, backgroundTargetPosition, parallaxSmoothing * Time.deltaTime);
		}

	}

	public void AddBackground(Transform bg)
	{
		backgrounds.Add(bg);
		parallaxScales.Add(bg.position.z * -1.0f);
	}
}
