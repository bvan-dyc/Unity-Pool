using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
	public bool moveVertical = false;
	public bool moveHorizontal = true;
	public float speed = 1.0f;
	public float travelDuration = 2.0f;
	private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
		timer = travelDuration;
    }

	// Update is called once per frame
	void Update()
	{
		transform.Translate(moveHorizontal ? speed : 0f, moveVertical ? speed : 0f, 0);
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			speed = -speed;
			timer = travelDuration;
		}
	}
}
