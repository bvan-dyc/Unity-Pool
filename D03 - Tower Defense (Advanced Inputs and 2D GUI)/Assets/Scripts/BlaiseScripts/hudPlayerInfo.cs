using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Sprites;
public class hudPlayerInfo : MonoBehaviour
{
	public gameManager manager;
	public Text health;
	public Text energy;

	// Update is called once per frame
	void Update()
	{
		health.text = manager.playerHp.ToString() + "hp";
		energy.text = manager.playerEnergy.ToString();
	}
}
