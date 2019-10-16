using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public bool opened = false;
	public bool horizontalOpening = false;
	public float speed = 0.05f;
	public float distance = 2f;
	private Vector3 origin;
	// Start is called before the first frame update
	void Start()
    {
		origin = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
		if (opened == true)
		{
			if (!horizontalOpening && transform.position.y > origin.y - distance)
				transform.Translate(0, -speed, 0);
			if (horizontalOpening && transform.position.x > origin.x - distance)
				transform.Translate(-speed, 0, 0);
		}
		if (opened == false)
		{
			if (!horizontalOpening && transform.position.y < origin.y)
				transform.Translate(0, speed, 0);
			if (horizontalOpening && transform.position.x < origin.x)
				transform.Translate(speed, 0, 0);
		}
	}

	public void open()
	{
		opened = true;
	}

	public void close()
	{
		opened = false;
	}
}
