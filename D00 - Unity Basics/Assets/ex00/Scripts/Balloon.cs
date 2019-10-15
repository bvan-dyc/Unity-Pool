using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
	[Header("Stamina")]
	[Range(0, 50)] public float baseStamina = 10.0F;
	[Range(0, 50)] public float maxstamina = 10.0F;
	[Range(0, 10)] public float cost = 2.0F;
	[Range(0, 10)] public float regen = 0.2F;
	public Slider staminaSlider;
	public Image fill;
	[Header("Size")]
	[Range(0, 10)] public float maxsize = 3.0F;
	[Range(0, 10)] public float minsize = 0.3F;
	public Vector3 growth = new Vector3(0.1F, 0.1F, 0.1F);
	public Vector3 deflation = new Vector3(0.1F, 0.1F, 0.1F);

	// Use this for initialization
	void Start()
	{
		staminaSlider.value = baseStamina;
		fill.color = Color.green;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space") && baseStamina > cost)
		{
			transform.localScale += growth;
			baseStamina -= cost;
		}
		else
		{
			baseStamina += regen;
			transform.localScale -= deflation;
		}
		if (transform.localScale.x >= maxsize || transform.localScale.x <= minsize)
		{
			Destroy(gameObject);
			Debug.Log("Baloon life time:" + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
		}
		if (baseStamina < cost)
		{
			fill.color = Color.red;
		}
		else if (fill.color == Color.red)
			fill.color = Color.green;
		staminaSlider.value = baseStamina;
	}
}
