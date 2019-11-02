using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
	private TankController player;

	public bool canControl = true;
	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<TankController>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (canControl)
		{
			player.MoveTank(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), Input.GetKey(KeyCode.LeftShift));
			player.MoveCannon(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
			if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
			{
				player.Shoot(Input.GetMouseButton(1));
			}
		}
	}
}
