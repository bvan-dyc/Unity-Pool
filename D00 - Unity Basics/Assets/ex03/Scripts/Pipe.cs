using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	public float resetX = -8;
	private Vector3 startingPosition;
	private void Start()
	{
		startingPosition = transform.position;
	}
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= resetX)
			transform.position = startingPosition;
	}
}
