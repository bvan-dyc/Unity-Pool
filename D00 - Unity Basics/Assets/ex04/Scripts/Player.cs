using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public bool useArrows = false;
	public float playerSpeed = 0.05f;
	public float playerHeight = 4.0f;
	public float YBounds = 4.9f;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (useArrows == true)
		{
			if (Input.GetKey("up") && transform.position.y + playerHeight / 2 < YBounds)
				transform.Translate(new Vector3(0, playerSpeed, 0));
			if (Input.GetKey("down") && transform.position.y - playerHeight / 2 > -YBounds)
				transform.Translate(new Vector3(0, -playerSpeed, 0));
		}
		else
		{
			if (Input.GetKey("w") && transform.position.y + playerHeight / 2 < YBounds)
				transform.Translate(new Vector3(0, playerSpeed, 0));
			if (Input.GetKey("s") && transform.position.y - playerHeight / 2 > -YBounds)
				transform.Translate(new Vector3(0, -playerSpeed, 0));
		}
	}
}
