using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float cameraSensitivity = 90;
	public float speed = 10;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		lookAtTarget(GameObject.FindGameObjectWithTag("Ball").gameObject.transform.position);
		rotationX = -90;
	}

	void Update()
	{
		rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp(rotationY, -90, 90);

		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
	}

	public void lookAtTarget(Vector3 position)
	{
		transform.LookAt(position);
	}
	public void move(float vertical)
	{
		transform.position += transform.forward * speed * vertical * Time.deltaTime;
	}

	public void moveLeft()
	{
		transform.position += -transform.right * speed * Time.deltaTime;
	}

	public void moveRight()
	{
		transform.position += transform.right * speed * Time.deltaTime;
	}

	public void birdEye()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + 30, transform.position.x);
	}
}
