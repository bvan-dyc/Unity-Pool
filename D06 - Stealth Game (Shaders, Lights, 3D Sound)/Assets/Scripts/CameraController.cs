using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float mouseSensitivity = 5.0f;
	public float smoothFactor = 2.0f;
	private Vector2 mouseLook;
	private Vector2 smoothV;
	public GameObject character;

	void Start()
	{
		character = this.transform.parent.gameObject;
	}

	public void LookAtMouse(float mouseX, float mouseY)
	{
		Vector2 mouseLookAt = new Vector2(mouseX, mouseY);
		mouseLookAt = Vector2.Scale(mouseLookAt, new Vector2(mouseSensitivity * smoothFactor, mouseSensitivity * smoothFactor));
		smoothV.x = Mathf.Lerp(smoothV.x, mouseLookAt.x, 1f / smoothFactor);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseLookAt.y, 1f / smoothFactor);
		mouseLook += smoothV;

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
	}
}
