using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public bool opened = false;
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
			if (transform.position.y > origin.y - distance)
				transform.Translate(0, -speed, 0);
		}
		if (opened == false)
		{
			if (transform.position.y < origin.y)
				transform.Translate(0, speed, 0);
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
