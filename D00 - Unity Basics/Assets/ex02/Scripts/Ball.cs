using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed = 0f;
	public Vector3 direction = new Vector3 (0f, 0f, 0f);
	public float deceleration = 0.05f;
	public float xbounds_min = -3;
	public float xbounds_max = 3;
	public float ybounds_min = -5;
	public float ybounds_max = 5;
	public float ballRadius = 0.40f;
	public Vector3 holePosition = new Vector3(0f, 3.5f, 0f);
	public float holeTolerance = 0.40f;
	public float minSpeedToEnterHole = 2f;
	private int score = -15;
	public bool gameEnded = false;
	public bool ballStopped = true;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate() {
		speed = speed > 0f ? speed - deceleration : 0f;
		if (transform.position.x - ballRadius <= xbounds_min || transform.position.x + ballRadius >= xbounds_max ||
			transform.position.y - ballRadius <= ybounds_min || transform.position.y + ballRadius >= ybounds_max)
		{
			direction = -direction;
		}
		if (speed > 0)
		{
			ballStopped = false;
			transform.Translate(speed * direction * Time.deltaTime);
		}
		else if (!gameEnded && !ballStopped)
		{
			score += 5;
			ballStopped = true;
			Debug.Log("Score: " + score);
		}
		if (speed <= minSpeedToEnterHole)
		{
			if (transform.position.x <= holePosition.x + holeTolerance && transform.position.x >= holePosition.x - holeTolerance &&
				transform.position.y <= holePosition.y + holeTolerance && transform.position.y >= holePosition.y - holeTolerance)
			{
				if (!gameEnded)
				{
					if (score > 0)
						Debug.Log("Your score is " + score + ". It's a loss.");
					else
						Debug.Log("Congratulations! Your score is " + score);
				}
				else
					gameEnded = true;
			}
		}
	}
}
