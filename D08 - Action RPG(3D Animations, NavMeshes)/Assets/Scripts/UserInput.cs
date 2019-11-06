using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
	private PlayerController player;

	public bool canControl = true;
	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (canControl)
		{
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
				{
					if (hit.transform.gameObject.tag == "enemy" && !hit.transform.gameObject.GetComponent<Damageable>().dead)
					{
						player.setTarget(hit.transform.gameObject);
					}
					else
						player.moveTo(hit.point);
				}
			}
		}
	}
}
