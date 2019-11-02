using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Vector3 target;
	public float speed = 1;
	public float destroyAfterTime = 0;
    void FixedUpdate()
    {
		if (Time.time > destroyAfterTime)
			Destroy(gameObject);
		transform.LookAt(target);
		transform.Translate(Vector3.forward * speed);
    }
}
