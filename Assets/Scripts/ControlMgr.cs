using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;

	private void Awake()
	{
		inst = this;
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

    private bool isUp = false;
	void RunPlayerControls()
	{
		GameObject player = EntityMgr.inst.playerEntityObject;

		if (Input.GetKeyDown(KeyCode.UpArrow) && isUp != true)
		{
			Vector3 newPos = player.transform.localPosition;
			newPos.y += 4;
			player.transform.localPosition = newPos;
            isUp = true;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) && isUp != false)
		{
			Vector3 newPos = player.transform.localPosition;
			newPos.y -= 4;
			player.transform.localPosition = newPos;
            isUp = false;
		}
	}
}
