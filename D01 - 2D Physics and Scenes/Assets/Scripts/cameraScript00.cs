using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraScript00 : MonoBehaviour
{
	public GameObject playerA;
	public GameObject playerB;
	public GameObject playerC;
	private int playerid;
	// Use this for initialization

	void Start()
	{
		playerid = 1;
		playerA.GetComponent<playermove00>().enableControl();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("1"))
		{
			playerid = 1;
			playerA.GetComponent<playermove00>().enableControl();
			playerB.GetComponent<playermove00>().disableControl();
			playerC.GetComponent<playermove00>().disableControl();
		}
		if (Input.GetKey("2"))
		{
			playerid = 2;
			playerA.GetComponent<playermove00>().disableControl();
			playerB.GetComponent<playermove00>().enableControl();
			playerC.GetComponent<playermove00>().disableControl();
		}
		if (Input.GetKey("3"))
		{
			playerid = 3;
			playerA.GetComponent<playermove00>().disableControl();
			playerB.GetComponent<playermove00>().disableControl();
			playerC.GetComponent<playermove00>().enableControl();
		}
		if (playerid == 1)
			transform.position = new Vector3(playerA.transform.position.x, playerA.transform.position.y, transform.position.z);
		if (playerid == 2)
			transform.position = new Vector3(playerB.transform.position.x, playerB.transform.position.y, transform.position.z);
		if (playerid == 3)
			transform.position = new Vector3(playerC.transform.position.x, playerC.transform.position.y, transform.position.z);
	}
}
