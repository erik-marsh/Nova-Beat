using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;

	public enum PlayerPosition
	{
		CENTER,
		UP,
		DOWN
	}

	//private bool isUp = false;
	private GameObject player;
	public PlayerPosition playerState = PlayerPosition.CENTER;
	public PlayerPosition lastPlayerState = PlayerPosition.CENTER;


	private void Awake()
	{
		inst = this;
	}

	private void Start()
	{
		// putting this in Start() makes sure EntityMgr is intialized before calling on it
		player = EntityMgr.inst.playerEntityObject;
	}

	void Update()
    {
		RunSystemControls();
		RunPlayerControls();
	}

	void RunSystemControls()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
	}

	void RunPlayerControls()
	{
		//GameObject player = EntityMgr.inst.playerEntityObject;

		//if (Input.GetKeyDown(KeyCode.UpArrow) && isUp != true)
		//{
		//	Vector3 newPos = player.transform.localPosition;
		//	newPos.y += 4;
		//	player.transform.localPosition = newPos;
		//          isUp = true;
		//}
		//else if (Input.GetKeyDown(KeyCode.DownArrow) && isUp != false)
		//{
		//	Vector3 newPos = player.transform.localPosition;
		//	newPos.y -= 4;
		//	player.transform.localPosition = newPos;
		//          isUp = false;
		//}
		Vector3 posVector = player.transform.localPosition;

		// different player states have different input priorities
		// ex. if you are up, you should check to see if down was pressed before you check if up is held

		if (playerState == PlayerPosition.UP)
		{
			if (Input.GetKeyDown(KeyCode.DownArrow)) // check if down was pressed
			{
				posVector.y -= 8;
				playerState = PlayerPosition.DOWN;
			}
			else if (Input.GetKey(KeyCode.UpArrow)) // otherwise, check if the player is still holding up
			{
				// nothing needs to change
			}
			else // otherwise, return to center
			{
				posVector.y -= 4;
				playerState = PlayerPosition.CENTER;
			}
		}
		else if (playerState == PlayerPosition.DOWN)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) // check if up was pressed
			{
				posVector.y += 8;
				playerState = PlayerPosition.UP;
			}
			else if (Input.GetKey(KeyCode.DownArrow)) // otherwise, check if the player is still holding down
			{
				// nothing needs to change
			}
			else // otherwise, return to center
			{
				posVector.y += 4;
				playerState = PlayerPosition.CENTER;
			}
		}
		else // center state
		{
			if (Input.GetKeyDown(KeyCode.DownArrow)) // check if down was pressed
			{
				posVector.y -= 4;
				playerState = PlayerPosition.DOWN;
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)) // check if up was pressed
			{
				posVector.y += 4;
				playerState = PlayerPosition.UP;
			}
			// else do nothing
		}

		// update position, finally
		player.transform.localPosition = posVector;

		//if (Input.GetKey(KeyCode.UpArrow))
		//{
		//	if (playerState == PlayerPosition.CENTER)
		//	{
		//		posVector.y += 4;
		//	}
		//	else if (playerState == PlayerPosition.DOWN)
		//	{
		//		posVector.y += 8;
		//	}

		//	player.transform.localPosition = posVector;
		//	playerState = PlayerPosition.UP;
		//}
		//else if (Input.GetKey(KeyCode.DownArrow))
		//{
		//	if (playerState == PlayerPosition.CENTER)
		//	{
		//		posVector.y -= 4;
		//	}
		//	else if (playerState == PlayerPosition.UP)
		//	{
		//		posVector.y -= 8;
		//	}

		//	player.transform.localPosition = posVector;
		//	playerState = PlayerPosition.DOWN;
		//}


		//if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) // neither key is being pressed; return to center
		//{
		//	if (playerState == PlayerPosition.UP)
		//	{
		//		posVector.y -= 4;
		//	}
		//	else if (playerState == PlayerPosition.DOWN)
		//	{
		//		posVector.y += 4;
		//	}

		//	player.transform.localPosition = posVector;
		//	playerState = PlayerPosition.CENTER;
		//}






		//else if (Input.GetKeyUp(KeyCode.UpArrow) && playerPos == PlayerPosition.UP)
		//{
		//	posVector.y -= 4;
		//	player.transform.localPosition = posVector;
		//	playerPos = PlayerPosition.CENTER;
		//}
		//else if (Input.GetKeyUp(KeyCode.DownArrow) && playerPos == PlayerPosition.DOWN)
		//{
		//	posVector.y += 4;
		//	player.transform.localPosition = posVector;
		//	playerPos = PlayerPosition.CENTER;
		//}
	}
}
