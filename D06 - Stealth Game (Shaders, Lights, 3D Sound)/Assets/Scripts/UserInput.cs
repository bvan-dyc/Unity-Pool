using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
	public PlayerController character;
	public CameraController camController;
	public bool canControl = true;
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (canControl)
		{
			camController.LookAtMouse(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
			if (Input.GetKey(KeyCode.LeftShift))
				character.Run(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
			else
				character.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
		}
    }
}
