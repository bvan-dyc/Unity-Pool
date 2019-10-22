using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
	[SerializeField] private CameraController camControl = null;
	[SerializeField] private Club club = null;
	private bool canControl = true;
	private void FixedUpdate()
	{
		if (canControl)
		{
			camControl.move(Input.GetAxis("Vertical"));
			if (Input.GetKey(KeyCode.Q))
				camControl.moveLeft();
			if (Input.GetKey(KeyCode.E))
				camControl.moveRight();
			if (Input.GetKeyUp(KeyCode.Space))
				club.triggerClub();
		}
	}

	public void disableControl()
	{
		canControl = false;
	}

	public void enableControl()
	{
		canControl = true;
	}
}
