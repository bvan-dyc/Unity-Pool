using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public float gravity;
	public bool status = true;
	public float flap;
	public float speed;
	public GameObject pipeA;
	public float pipeThickness;
	public float minHeight = -3f;
	public float pipeGap;
	public int score = 0;
	private float time;
	public float resetX = -8;

	// Update is called once per frame
	void Update()
	{
		if (status == true)
		{
			time += Time.deltaTime;
			pipeA.transform.Translate(new Vector3(-speed, 0.0F, 0.0F));
			if (Input.GetKeyDown("space"))
				transform.Translate(new Vector3(0, flap, 0));
			else
				transform.Translate(new Vector3(0, gravity, 0));
			if (transform.position.y <= minHeight)
			{
				Debug.Log("Score: " + score);
				Debug.Log("Time: " + Mathf.RoundToInt(time) + "s");
				status = false;
			}
			if (pipeA.transform.position.x <= resetX)
			{
				score += 5;
				speed += 0.02F;
			}
			checkCollision();
		}
	}

	private void checkCollision()
	{
		if ((transform.position.x >= pipeA.transform.position.x - pipeThickness / 2 &&
			transform.position.x <= pipeA.transform.position.x + pipeThickness / 2))
		{
			if (!(transform.position.y >= pipeA.transform.position.y - pipeGap / 2 &&
				transform.position.y <= pipeA.transform.position.y + pipeGap / 2))
				gameOver();
		}
	}

	private void gameOver()
	{
		Debug.Log("Score: " + score + '\n' + "Time: " + Mathf.RoundToInt(time) + "s");
		status = false;
	}
}