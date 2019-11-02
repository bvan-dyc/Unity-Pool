using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
	private PlayerController player;
	public bool canControl = true;
	public static UserInput Instance
	{
		get { return s_Instance; }
	}

	protected static UserInput s_Instance;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update()
	{
		if (canControl)
		{
			if (Input.GetMouseButton(0))
			{
				RaycastHit hit;
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
				{
					if (hit.transform.gameObject.tag == "enemy")
					{
						player.setTarget(hit.transform.gameObject);
					}
					else
						player.moveTo(hit.point);
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
				player.TriggerSkill(0);
			if (Input.GetKeyDown(KeyCode.Alpha2))
				player.TriggerSkill(1);
			if (Input.GetKeyDown(KeyCode.Alpha3))
				player.TriggerSkill(2);
			if (Input.GetKeyDown(KeyCode.Alpha4))
				player.TriggerSkill(3);
			if (Input.GetKeyDown(KeyCode.O))
				player.makeInvincible();
			if (Input.GetKeyDown(KeyCode.P))
				player.forceLevelUp();
		}
	}
	public void resetPlayerState()
	{
		player.state = PlayerController.PlayerState.idle;
	}
}
