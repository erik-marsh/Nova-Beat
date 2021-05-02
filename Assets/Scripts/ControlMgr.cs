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

	public List<BoxCollider> reflectionScoreZones = new List<BoxCollider>();
	public List<BoxCollider> topScoreZones = new List<BoxCollider>();
	public List<BoxCollider> bottomScoreZones = new List<BoxCollider>();
	public BoxCollider topMissZone;
	public BoxCollider bottomMissZone;

	//private bool isUp = false;
	private GameObject player;
	private PlayerPosition playerState = PlayerPosition.CENTER;

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
				// the emptiness of this if statement is actually important, don't remove it
			}
			else if (Input.GetKey(KeyCode.DownArrow)) // THEN we check if down is still held and update accordingly
			{
				posVector.y -= 8;
				playerState = PlayerPosition.DOWN;
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
				// the emptiness of this if statement is actually important, don't remove it
			}
			else if (Input.GetKey(KeyCode.UpArrow)) // THEN we check if up is still held and update accordingly
			{
				posVector.y += 8;
				playerState = PlayerPosition.UP;
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
	}
}
