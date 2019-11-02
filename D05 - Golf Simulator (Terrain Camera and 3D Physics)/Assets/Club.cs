using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Club : MonoBehaviour
{
	public Slider powerSlider;
	public GameObject hole;
	private float numberOfHits = 0;
	public Text nHitsText;
	private float power = 0;
	public float maxPower = 50;
	public float powerIncrement = 5f;
	public int invertFrequency = 10;
	private clubState state = clubState.idle;
	private Rigidbody ball;
	public CameraController cam;
	public enum clubState
	{
		idle,
		gauging,
		waiting
	}

	private void Start()
	{
		ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (state == clubState.gauging)
		{
			if (power < maxPower)
				power += powerIncrement * Time.deltaTime;
			if (Random.Range(0, invertFrequency) == 0 || power <= 0 || power >= maxPower)
				powerIncrement = -powerIncrement;
			powerSlider.value = power;
		}
		if (state == clubState.waiting)
		{
			if (ball.velocity.x == 0 && ball.velocity.y == 0)
			{
				nextShot();
			}
		}
	}

	public void triggerClub()
	{
		if (state == clubState.idle)
			state = clubState.gauging;
		else if (state == clubState.gauging)
		{
			ShootBall();
			state = clubState.waiting;
		}
	}

	private void nextShot()
	{
		state = clubState.idle;
		Vector3 newPosition = ball.transform.position - (hole.transform.position - ball.transform.position).normalized * 3;
		newPosition.y += 5;
		cam.transform.position = newPosition;
		cam.lookAtTarget(ball.transform.position);
	}
	private void ShootBall()
	{
		Vector3 direction = (hole.transform.position - ball.transform.position);
		direction.y += power * 5;
		ball.AddForce(direction * power, ForceMode.Impulse);
		power = 0;
		powerSlider.value = power;
		numberOfHits++;
		nHitsText.text = numberOfHits.ToString();
	}
}
