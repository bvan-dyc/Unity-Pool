using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Rigidbody rbody;
	public float minSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
		rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (rbody.velocity.x < minSpeed || rbody.velocity.y < minSpeed)
			rbody.velocity = new Vector3(0, 0, 0);
    }
}
