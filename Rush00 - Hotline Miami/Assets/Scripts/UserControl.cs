using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
	private CharacterController2D character;
	private bool canControl = true;

    void Awake()
	{
		character = GetComponent<CharacterController2D>();
	}

	private void FixedUpdate()
	{
		if (canControl)
		{
			float movementX = Input.GetAxis("Horizontal");
			float movementY = Input.GetAxis("Vertical");

			character.Move(movementX, movementY);
			if (Input.GetMouseButton(0))
				character.triggerAttack();
			if (Input.GetMouseButton(1))
				character.Throw();
			if (Input.GetKeyDown(KeyCode.E))
				character.pickUp();
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
