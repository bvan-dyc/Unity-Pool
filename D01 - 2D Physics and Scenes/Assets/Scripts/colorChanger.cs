using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
	public GameObject objectToChange;
	public SpriteRenderer spriteToChange;

	void OnTriggerEnter2D(Collider2D other)
	{
		objectToChange.tag = other.tag;
		spriteToChange.color = getNewColor(other.tag);
		objectToChange.layer = getNewLayer(other.tag);
	}

	Color getNewColor(string tag)
	{
		if (tag == "Red")
			return (new Color32(244, 57, 57, 255));
		else if (tag == "Blue")
			return (new Color32(8,86,152, 255));
		else if (tag == "Yellow")
			return (new Color32(255, 237, 0, 255));
		else
			return Color.white;
	}

	LayerMask getNewLayer(string tag)
	{
		return LayerMask.NameToLayer(tag);
	}
}
