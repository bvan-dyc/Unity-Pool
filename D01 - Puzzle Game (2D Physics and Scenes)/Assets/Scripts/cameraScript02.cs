using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraScript02 : MonoBehaviour
{
	public GameObject playerA;
	public GameObject playerB;
	public GameObject playerC;
	private int playerid;
	// Use this for initialization

	void Start()
	{
		playerid = 1;
		playerA.GetComponent<playermove02>().enableControl();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("1") && !playerC.GetComponent<playermove02>().isDead)
		{
			playerid = 1;
			playerA.GetComponent<playermove02>().enableControl();
			playerB.GetComponent<playermove02>().disableControl();
			playerC.GetComponent<playermove02>().disableControl();
		}
		if (Input.GetKey("2") && !playerC.GetComponent<playermove02>().isDead)
		{
			playerid = 2;
			playerA.GetComponent<playermove02>().disableControl();
			playerB.GetComponent<playermove02>().enableControl();
			playerC.GetComponent<playermove02>().disableControl();
		}
		if (Input.GetKey("3") && !playerC.GetComponent<playermove02>().isDead)
		{
			playerid = 3;
			playerA.GetComponent<playermove02>().disableControl();
			playerB.GetComponent<playermove02>().disableControl();
			playerC.GetComponent<playermove02>().enableControl();
		}
		if (playerid == 1 && !playerA.GetComponent<playermove02>().isDead)
			transform.position = new Vector3(playerA.transform.position.x, playerA.transform.position.y, transform.position.z);
		if (playerid == 2 && !playerB.GetComponent<playermove02>().isDead)
			transform.position = new Vector3(playerB.transform.position.x, playerB.transform.position.y, transform.position.z);
		if (playerid == 3 && !playerC.GetComponent<playermove02>().isDead)
			transform.position = new Vector3(playerC.transform.position.x, playerC.transform.position.y, transform.position.z);
	}
}
