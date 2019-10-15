using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
	public Transform player1;
	public Transform player2;
	public float ballRadius = 0.5f;
	public float playerWidth = 0.46f;
	public float playerHeight = 4.0f;
	public float speed = 0.05f;
	public float tolerance = 0.25f;
	private Vector3 direction = new Vector3(1, 0, 0);
	public float YBounds = 4.9f;
	public float XBounds = 8.9f;
	public float distanceBeforeReset = 6.1f;
	private int player1Score = 0;
	private int player2Score = 0;

	// Start is called before the first frame update
	void Start()
	{
		speed = Random.Range(0, 2) > 0 ? speed : -speed;
		direction = new Vector3(speed, speed * Random.Range(-1f, 1f), 0);
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(direction);
		checkPlayerHit(player1);
		checkPlayerHit(player2);
		if (transform.position.y + ballRadius >= YBounds ||
			transform.position.y - ballRadius <= -YBounds)
			direction = new Vector3(direction.x, -direction.y, 0);
		if (transform.position.x - ballRadius <= -XBounds - distanceBeforeReset)
		{
			player2Score++;
			Debug.Log("Player 1: " + player1Score + " | Player2: " + player2Score);
			ResetField();
		}
		if (transform.position.x + ballRadius >= XBounds + distanceBeforeReset)
		{
			player1Score++;
			Debug.Log("Player 1: " + player1Score + " | Player2: " + player2Score);
			ResetField();
		}
	}

	private void checkPlayerHit(Transform player)
	{
		if (transform.position.x + ballRadius >= player.position.x - playerWidth / 2 &&
				transform.position.x - ballRadius <= player.position.x - tolerance)
		{
			if (transform.position.y - ballRadius < player.position.y + playerHeight / 2 &&
				transform.position.y + ballRadius > player.position.y - playerHeight / 2)
				direction = new Vector3(-direction.x, -direction.y, 0);
		}
	}
	private void ResetField()
	{
		transform.position = new Vector3(0, 0, 0);
		direction = new Vector3(speed, speed * Random.Range(-100, 100) / 100, 0);
	}
}
