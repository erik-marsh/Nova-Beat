using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;

	public enum PlayerPosition
	{
		CENTER,
		UP,
		DOWN
	}

	public float moveDistance = 1.76f;

	//private bool isUp = false;
	private GameObject player;
	private PlayerPosition playerState = PlayerPosition.CENTER;

    public AudioSource beatSound;

    public GameObject reflectionSprite;

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
        if (Input.GetKeyDown(KeyCode.F))
        {
            UIMgr.inst.scoreCounterScript.SaveScores();
            SceneManager.LoadScene("EndScreen");
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
                beatSound.Play();
                posVector.y -= 2 * moveDistance;
				playerState = PlayerPosition.DOWN;
			}
			else if (Input.GetKey(KeyCode.UpArrow)) // otherwise, check if the player is still holding up
			{
				// nothing needs to change
				// the emptiness of this if statement is actually important, don't remove it
			}
			else if (Input.GetKey(KeyCode.DownArrow)) // THEN we check if down is still held and update accordingly
			{
                beatSound.Play();
                posVector.y -= 2 * moveDistance;
				playerState = PlayerPosition.DOWN;
			}
			else // otherwise, return to center
			{
				posVector.y -= moveDistance;
				playerState = PlayerPosition.CENTER;
			}
		}
		else if (playerState == PlayerPosition.DOWN)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) // check if up was pressed
			{
                beatSound.Play();
                posVector.y += 2 * moveDistance;
				playerState = PlayerPosition.UP;
			}
			else if (Input.GetKey(KeyCode.DownArrow)) // otherwise, check if the player is still holding down
			{
				// nothing needs to change
				// the emptiness of this if statement is actually important, don't remove it
			}
			else if (Input.GetKey(KeyCode.UpArrow)) // THEN we check if up is still held and update accordingly
			{
                beatSound.Play();
                posVector.y += 2 * moveDistance;
				playerState = PlayerPosition.UP;
			}
			else // otherwise, return to center
			{
				posVector.y += moveDistance;
				playerState = PlayerPosition.CENTER;
			}
		}
		else // center state
		{
			if (Input.GetKeyDown(KeyCode.DownArrow)) // check if down was pressed
			{
                beatSound.Play();
                posVector.y -= moveDistance;
				playerState = PlayerPosition.DOWN;
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)) // check if up was pressed
			{
                beatSound.Play();
                posVector.y += moveDistance;
				playerState = PlayerPosition.UP;
			}
			// else do nothing
		}

		// update position, finally
		player.transform.localPosition = posVector;

        //Shows reflection beam if player is pressing Z
        if (Input.GetKey(KeyCode.Z))
        {
            reflectionSprite.SetActive(true);
        }
        else
        {
            reflectionSprite.SetActive(false);
        }

	}
}
