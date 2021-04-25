using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class BackgroundTiling : MonoBehaviour
{
	public int offsetX = 2;

	public bool hasRightBuddy = false;
	public bool hasLeftBuddy = false;
	public bool reverseScale = false; // if object is not tilable

	private float spriteWidth = 0.0f;
	private Camera cam;
	private Transform currTransform;

	private void Awake()
	{
		cam = Camera.main;
		currTransform = transform;
	}

	private void Start()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = spriteRenderer.sprite.bounds.size.x * transform.localScale.x;
	}

	private void Update()
	{
		if (!hasLeftBuddy || !hasRightBuddy)
		{
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

			float edgeVisiblePositionRight = (transform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (transform.position.x - spriteWidth / 2) + camHorizontalExtend;

			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasRightBuddy)
			{
				MakeNewBuddy(1);
				hasRightBuddy = true;
			}
			else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasLeftBuddy)
			{
				MakeNewBuddy(-1);
				hasLeftBuddy = true;
			}
		}
	}

	private void MakeNewBuddy(int rightOrLeft)
	{
		Vector3 newPosition = new Vector3(transform.position.x + spriteWidth * rightOrLeft, transform.position.y, transform.position.z);
		Transform newBuddy = (Transform)Instantiate(transform, newPosition, transform.rotation);

		if (reverseScale)
		{
			newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1.0f, newBuddy.localScale.y, newBuddy.localScale.z);
		}

		newBuddy.parent = transform.parent;

		if (rightOrLeft > 0)
		{
			newBuddy.GetComponent<BackgroundTiling>().hasLeftBuddy = true;
		}
		else
		{
			newBuddy.GetComponent<BackgroundTiling>().hasRightBuddy = true;
		}

		BackgroundMovement.inst.AddBackground(newBuddy);
	}
}
