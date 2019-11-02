using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stealth : MonoBehaviour
{
	public Slider stealthSlider;
	public float runIncrement = 1f;
	public float detectIncrement = 0.5f;
	public float smokeDecrement = 0.3f;
	public float alertDecrement = 0.25f;
	private float alert = 0f;
	private PlayerController character;
	public void Start()
	{
		character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	public void FixedUpdate()
	{
		if (alert >= 100)
			return;
		float alertIncrement = (character.isPlayerRunning() ? runIncrement : 0) + 
								(character.playerIsDetected() ? detectIncrement - (character.playerInSmoke() ? smokeDecrement : 0) : 0);
		alert += alertIncrement > 0 ? alertIncrement : -alertDecrement ;
		if (alert < 0)
			alert = 0;
		stealthSlider.value = alert;
	}

	public float getAlertLevel()
	{
		return (alert);
	}
}
