using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float timer;
	public float timeBeforeAutodestruct = -1.0f;

	private void OnEnable()
	{
		timer = 0.0f;
	}

	void FixedUpdate()
	{
		if (timeBeforeAutodestruct > 0)
		{
			timer += Time.deltaTime;
			if (timer > timeBeforeAutodestruct)
			{
				destroyBullet();
			}
		}
	}

	public void destroyBullet()
	{
		Destroy(gameObject);
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.GetComponent<playermove02>())
			col.gameObject.GetComponent<playermove02>().kill();
		destroyBullet();
	}
}
