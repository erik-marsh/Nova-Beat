using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	public Transform[] backgrounds;
	public float[] parallaxScales; // proportion of camera's mvmt to move bgs by
	public float smoothing = 1.0f;          // < 0

	private Transform cam;
	private Vector3 previousCamPos;

	private void Awake()
	{
		cam = Camera.main.transform;
	}

	private void Start()
	{
		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++)
		{
			parallaxScales[i] = backgrounds[i].position.z * -1.0f;
		}
	}

	private void Update()
	{
		for (int i = 0; i < backgrounds.Length; i++)
		{
			// parallax is opposite of camera movement
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
			float backgroundTargetPositionX = backgrounds[i].position.x + parallax;
			Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);

			// smooth position changes
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
		}

		previousCamPos = cam.position;
	}
}
