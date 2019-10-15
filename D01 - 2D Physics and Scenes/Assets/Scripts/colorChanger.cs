using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
	public GameObject objectToChange;
	public SpriteRenderer spriteToChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		objectToChange.tag = other.tag;
		spriteToChange.color = getNewColor(other.tag);
		objectToChange.layer = getNewLayer(other.tag);
	}

	Color getNewColor(string tag)
	{
		if (tag == "Red")
			return Color.red;
		if (tag == "Blue")
			return Color.blue;
		if (tag == "Yellow")
			return Color.yellow;
		else
			return Color.white;
	}

	LayerMask getNewLayer(string tag)
	{
		return LayerMask.NameToLayer(tag);
	}
}
