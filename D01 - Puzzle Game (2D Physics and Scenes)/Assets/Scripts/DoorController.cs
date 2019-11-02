using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	public GameObject[] doors;
	public SpriteRenderer sprite;
	public bool isPaletteSwitch = false;
	private string switchColor = "white";

	void OnTriggerEnter2D(Collider2D other)
	{
		if (isPaletteSwitch)
		{
			if (other.tag == "Yellow")
				sprite.color = Color.yellow;
			if (other.tag == "Red")
				sprite.color = Color.red;
			if (other.tag == "Blue")
				sprite.color = Color.blue;
			switchColor = other.tag;
		}
		foreach (GameObject door in doors)
		{
			if (isPaletteSwitch)
			{
				if (door.tag == switchColor)
					door.GetComponent<Door>().open();
			}
			else
				door.GetComponent<Door>().open();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		foreach (GameObject door in doors)
		{
			door.GetComponent<Door>().close();
		}
		if (isPaletteSwitch)
		{
			sprite.color = Color.white;
			switchColor = "white";
		}
	}
}
