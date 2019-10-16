﻿using UnityEngine;
using System.Collections;

public class playermove00 : MonoBehaviour
{
	public float speed;
	private bool canControl = false;
	public float jumpPower;
	public LayerMask groundLayers;
	public Transform groundCheck;
	private const float GROUNDED_RADIUS = 0.3f;
	private Rigidbody2D rbody;

	bool isGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, GROUNDED_RADIUS, groundLayers);
	}

	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		if (!canControl)
			rbody.velocity = new Vector2(0, rbody.velocity.y);
	}

	public void disableControl()
	{
		canControl = false;
	}

	public void enableControl()
	{
		canControl = true;
	}
	void FixedUpdate()
	{
		float movement = Input.GetAxis("Horizontal");
		if (canControl)
			rbody.velocity = new Vector2(movement * speed, rbody.velocity.y);
		if (canControl && Input.GetKeyDown("space") && isGrounded())
		{
			rbody.velocity = new Vector2(rbody.velocity.x, jumpPower);
		}
	}
}
