using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {
	public Ball ball;
	public Transform ballTransform;
	private float strength = 0.0f;
	public float maxStrength = 8.0f;
	public float strengthIncrement = 0.1f;
	private bool isPressingSpace = false;
	private Vector3 originalPosition;
	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKey("space") && ball.speed == 0)
		{
			if (!isPressingSpace)
			{
				transform.position = new Vector3(ballTransform.position.x - 0.2f, ballTransform.position.y - 0.2f, 0);
				originalPosition = transform.position;
			}
			if (strength < maxStrength)
			{
				strength += strengthIncrement;
				transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
			}
			isPressingSpace = true;
		}
		else if (isPressingSpace == true)
		{
			transform.position = originalPosition;
			ball.speed = strength;
			strength = 0;
			ball.direction = new Vector3(0, 1, 0);
			isPressingSpace = false;
		}
	}
}
